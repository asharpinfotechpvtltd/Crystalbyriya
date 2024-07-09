using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Range
{
    public class DeleteModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public DeleteModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblRange TblRange { get; set; }

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

                TblRange = await _context.TblRange.FirstOrDefaultAsync(m => m.Id == id);

                if (TblRange == null)
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

            TblRange = await _context.TblRange.FindAsync(id);

            if (TblRange != null)
            {
                _context.TblRange.Remove(TblRange);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
