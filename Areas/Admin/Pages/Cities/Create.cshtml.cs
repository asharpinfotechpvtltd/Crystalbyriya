using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public CreateModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> StateList { get; set; }
        public IActionResult OnGet()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                StateList = _context.TblStates.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.StateId.ToString(),
                                      Text = a.StateName
                                  }).ToList();
                return Page();
            }
        }

        [BindProperty]
        public TblCities TblCities { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            

            _context.TblCities.Add(TblCities);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
