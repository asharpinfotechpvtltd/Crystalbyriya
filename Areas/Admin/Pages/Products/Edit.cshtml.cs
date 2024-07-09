using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Astaberry.Areas.Admin.Pages.Products
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
        public TblProduct TblProduct { get; set; }

        public List<SelectListItem> Options { get; set; }

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
                Options = _context.TblSizes.Select(a =>
                                     new SelectListItem
                                     {
                                         Value = a.Sizeid.ToString(),
                                         Text = a.Size
                                     }).ToList();

                TblProduct = await _context.TblProducts.FirstOrDefaultAsync(m => m.Id == id);

                if (TblProduct == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
        public IFormFile file { get; set; }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {   
            if (file!=null)
            {
                var files = Path.Combine(webHostEnvironment.WebRootPath, "img/HomeImages", file.FileName);
                using (var fileStream = new FileStream(files, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                TblProduct.THUMBNAIL = file.FileName;
            }
            _context.Attach(TblProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException db)
            {
                if (!TblProductExists(TblProduct.Id))
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

        private bool TblProductExists(int id)
        {
            return _context.TblProducts.Any(e => e.Id == id);
        }
    }
}
