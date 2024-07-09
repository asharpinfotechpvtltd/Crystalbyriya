using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.CouponCodes
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public CreateModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
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
        public TblCouponCode TblCouponCode { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            

            _context.TblCouponCodes.Add(TblCouponCode);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
