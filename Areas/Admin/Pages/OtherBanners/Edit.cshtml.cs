using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Astaberry.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Astaberry.Areas.Admin.Pages.OtherBanners
{
    public class EditModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(Astaberry.Models.ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        [BindProperty]
        public OtherBanner OtherBanners { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }

                OtherBanners = await _context.OtherBanners.FirstOrDefaultAsync(m => m.Id == id);

                if (OtherBanners == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int Id, string Url)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OtherBanners = _context.OtherBanners.Find(Id);
            var file = Path.Combine(webHostEnvironment.WebRootPath, "img/banner/cosmetic", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
            OtherBanners.Name = Upload.FileName;
            OtherBanners.Url = Url;
            await _context.SaveChangesAsync();

            _context.Attach(OtherBanners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblImageGalleryExists(OtherBanners.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblImageGalleryExists(int id)
        {
            return _context.TblImageGalleries.Any(e => e.Id == id);
        }
    }
}

    