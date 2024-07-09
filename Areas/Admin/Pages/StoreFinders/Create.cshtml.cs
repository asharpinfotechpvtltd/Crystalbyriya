using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.StoreFinders
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public CreateModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Cityoptions { get; set; }

        public IActionResult OnGet()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                Options = _context.TblStates.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.StateId.ToString(),
                                     Text = a.StateName
                                 }).ToList();

                Cityoptions = _context.TblCities.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.RegionId.ToString(),
                                      Text = a.Name
                                  }).ToList();
                return Page();
            }
        }

        [BindProperty]
        public TblStoreFinder TblStoreFinder { get; set; }
        [BindProperty]
        public TblState TblState { get; set; }

        public List<SelectListItem> Options { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.TblStoreFinders.Add(TblStoreFinder);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
