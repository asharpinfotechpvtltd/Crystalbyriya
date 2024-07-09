using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.CouponCodes
{
    public class DeleteModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public DeleteModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblCouponCode TblCouponCode { get; set; }

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

                TblCouponCode = await _context.TblCouponCodes.FirstOrDefaultAsync(m => m.Id == id);

                if (TblCouponCode == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblCouponCode = await _context.TblCouponCodes.FindAsync(id);

            if (TblCouponCode != null)
            {
                _context.TblCouponCodes.Remove(TblCouponCode);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
