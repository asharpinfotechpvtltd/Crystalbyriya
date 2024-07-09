using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Astaberry.Areas.Admin.Pages.Banners
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

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

                Options = _context.TblCategories.Select(a =>
                                     new SelectListItem
                                     {
                                         Value = a.Categoryname.ToString(),
                                         Text = a.Categoryname
                                     }).ToList();
                SubCatOptions = _context.TblSubCategories.Select(a =>
                                     new SelectListItem
                                     {
                                         Value = a.SubCategoryName.ToString(),
                                         Text = a.SubCategoryName
                                     }).ToList();
                return Page();
            }
        }

        [BindProperty]
        public TblBanner TblBanners { get; set; }


        public List<SelectListItem> Options { get; set; }
        public List<SelectListItem> SubCatOptions { get; set; }

        [BindProperty]
        public IFormFile DesktopImageNames { get; set; }
        [BindProperty]
        public IFormFile MobileImageNames { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            var file = Path.Combine(webHostEnvironment.WebRootPath, "img/slider/cosmetic", DesktopImageNames.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await DesktopImageNames.CopyToAsync(fileStream);
            }

            var mobilefile = Path.Combine(webHostEnvironment.WebRootPath, "img/slider/cosmetic", MobileImageNames.FileName);
            using (var fileStreams = new FileStream(mobilefile, FileMode.Create))
            {
                await MobileImageNames.CopyToAsync(fileStreams);                
            }           
            TblBanners.DesktopImageName = DesktopImageNames.FileName;
            TblBanners.MobileImageName = MobileImageNames.FileName;           

            _context.TblBanners.Add(TblBanners);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
