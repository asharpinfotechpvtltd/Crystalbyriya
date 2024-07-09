using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public EditModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblOrderId TblOrderId { get; set; }

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

                TblOrderId = await _context.TblOrderIds.FirstOrDefaultAsync(m => m.Id == id);

                if (TblOrderId == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblOrderId).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOrderIdExists(TblOrderId.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblOrderIdExists(int id)
        {
            return _context.TblOrderIds.Any(e => e.Id == id);
        }
    }
}
