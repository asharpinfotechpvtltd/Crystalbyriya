using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Astaberry.Areas.Admin.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public List<SelectListItem> Options { get; set; }

        public CreateModel(Astaberry.Models.ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
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
                Options = _context.TblSizes.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Sizeid.ToString(),
                                      Text = a.Size
                                  }).ToList();
                return Page();
            }
        }

        [BindProperty]
        public TblProduct TblProduct { get; set; }
        [BindProperty]
        public IFormFile file { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            var files = Path.Combine(webHostEnvironment.WebRootPath, "img/HomeImages", file.FileName);
            using (var fileStream = new FileStream(files, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            TblProduct.THUMBNAIL = file.FileName;
            _context.TblProducts.Add(TblProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
