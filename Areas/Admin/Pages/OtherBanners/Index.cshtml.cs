using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Astaberry.Areas.Admin.Pages.OtherBanners
{
    public class IndexModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public IndexModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OtherBanner> OtherBanners { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                OtherBanners = await _context.OtherBanners.Take(10).ToListAsync();
                return Page();
            }
        }
    }
}
