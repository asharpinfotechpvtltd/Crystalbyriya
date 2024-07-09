using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.ProductByConcern
{
    public class IndexModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public IndexModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TblProductByConcern> TblProductByConcern { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                TblProductByConcern = await _context.TblProductByConcerns.ToListAsync();
                return Page();
            }
        }

        public async Task OnPostSearch(string Skucode)
        {
            TblProductByConcern = await _context.TblProductByConcerns.Where(Sku=>Sku.SkuCode.Contains(Skucode)).ToListAsync();
        }
    }
}
