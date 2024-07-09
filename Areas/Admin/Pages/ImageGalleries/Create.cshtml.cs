using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.ImageGalleries
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context; 
        private readonly IWebHostEnvironment webHostEnvironment;

        public CreateModel(Astaberry.Models.ApplicationDbContext context,IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public TblImageGallery TblImageGallery { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string UrlBox)
        {
            if (UrlBox == null)
            {

                
                    var file = Path.Combine(webHostEnvironment.WebRootPath, "img/products", Upload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Upload.CopyToAsync(fileStream);
                    }
                    TblImageGallery.Url = Upload.FileName;                    
                    await _context.TblImageGalleries.AddAsync(TblImageGallery);
                    await _context.SaveChangesAsync();
                
            }
            else
            {

                TblImageGallery.Url = UrlBox;                
                await _context.TblImageGalleries.AddAsync(TblImageGallery);
                await _context.SaveChangesAsync();

            }

         
            return RedirectToPage("./Index");
        }
       
    }
}
