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

namespace Astaberry.Areas.Admin.Pages.JobPosting
{
    public class DeleteModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;
       

        public DeleteModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
           
        }

        [BindProperty]
        public JobOpening Tbljobopening { get; set; }

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

                Tbljobopening = await _context.TblJobOpenings.FirstOrDefaultAsync(m => m.Id == id);

                if (Tbljobopening == null)
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

            Tbljobopening = await _context.TblJobOpenings.FindAsync(id);

            if (Tbljobopening != null)
            {
                _context.TblJobOpenings.Remove(Tbljobopening);
                await _context.SaveChangesAsync();
            }

            


           

            return RedirectToPage("./Index");
            // return View("Edit");
        }
    }
}
