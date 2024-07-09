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

namespace Astaberry.Areas.Admin.Pages.StoreFinders
{
    public class EditModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public EditModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblStoreFinder TblStoreFinder { get; set; }

        [BindProperty]
        public TblState TblState { get; set; }

        public List<SelectListItem> Options { get; set; }

        public List<SelectListItem> Cityoptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
                if (id == null)
                {
                    return NotFound();
                }

                TblStoreFinder = await _context.TblStoreFinders.FirstOrDefaultAsync(m => m.StoreId == id);

                if (TblStoreFinder == null)
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
           

            _context.Attach(TblStoreFinder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblStoreFinderExists(TblStoreFinder.StoreId))
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

        private bool TblStoreFinderExists(int id)
        {
            return _context.TblStoreFinders.Any(e => e.StoreId == id);
        }
    }
}
