using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Astaberry.Areas.Admin.Pages.JobPosting
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
        public JobOpening TblJobPostings { get; set; }       

        public async Task<IActionResult> OnPostAsync()
        {                       

            _context.TblJobOpenings.Add(TblJobPostings);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
