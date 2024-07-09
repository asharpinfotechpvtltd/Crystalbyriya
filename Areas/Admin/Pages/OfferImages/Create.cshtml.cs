using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Astaberry.Areas.Admin.Pages.OfferImages
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
                return Page();
            }

        }

        [BindProperty]
        public TblOffersImage TblOffersImage { get; set; }


        [BindProperty]
        public IFormFile Offers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(bool Enabled)
        {
            var file = Path.Combine(webHostEnvironment.WebRootPath, "img/Offers", Offers.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Offers.CopyToAsync(fileStream);
            }
            TblOffersImage.Enable = Enabled;
            TblOffersImage.Image = Offers.FileName ;
            

            _context.TblOffersImages.Add(TblOffersImage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
