using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Banners
{
    public class DeleteModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DeleteModel(Astaberry.Models.ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        [BindProperty]
        public TblBanner TblImageGallery { get; set; }

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
                else
                {


                    TblImageGallery = await _context.TblBanners.FirstOrDefaultAsync(m => m.Id == id);

                    if (TblImageGallery == null)
                    {
                        return NotFound();
                    }
                    return Page();
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id,string DesktopImageName,string MobileImageName)
        {

            string fileDirectory = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/img/slider/cosmetic/");

            string webRootPath = webHostEnvironment.WebRootPath;
            var fileName = "";
            fileName = DesktopImageName;
            var fullPath = webRootPath + "/img/slider/cosmetic/" + fileName;

            var fileMobileName = MobileImageName;
            var fullPathMobile = webRootPath + "/img/slider/cosmetic/" + fileMobileName;

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                System.IO.File.Delete(fullPathMobile);

            }



            if (id == null)
            {
                return NotFound();
            }

            TblImageGallery = await _context.TblBanners.FindAsync(id);

            if (TblImageGallery != null)
            {
                _context.TblBanners.Remove(TblImageGallery);
                await _context.SaveChangesAsync();
            }

            


           

            return RedirectToPage("./Index");
            // return View("Edit");
        }
    }
}
