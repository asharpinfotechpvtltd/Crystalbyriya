using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public IndexModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<TblOrderId> TblOrderId { get; set; }


        public async Task<IActionResult> OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                

                IQueryable<TblOrderId> Orderlist =  _context.TblOrderIds.OrderByDescending(id => id.Id).AsQueryable();
               

                var pageSize = 10;
                TblOrderId = await PaginatedList<TblOrderId>.CreateAsync(
                    Orderlist.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
            return Page();
        }
   


        public async Task<IActionResult> OnPostSearch(string Status)
        {

            //TblOrderId = await _context.TblOrderIds.Where(id=>id.Status==Status).OrderByDescending(id => id.Id).ToListAsync();

            return Page();
        }
    }
}
