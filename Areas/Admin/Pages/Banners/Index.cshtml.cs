using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Banners
{
    public class IndexModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public IndexModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TblBanner> TblImageGallery { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                TblImageGallery = await _context.TblBanners.ToListAsync();
                return Page();
            }
        }
    }
}
