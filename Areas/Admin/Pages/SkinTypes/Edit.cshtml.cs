﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.SkinTypes
{
    public class EditModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public EditModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblSkinType TblSkinType { get; set; }

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

                TblSkinType = await _context.TblSkinTypes.FirstOrDefaultAsync(m => m.Skintypeid == id);

                if (TblSkinType == null)
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

            _context.Attach(TblSkinType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSkinTypeExists(TblSkinType.Skintypeid))
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

        private bool TblSkinTypeExists(int id)
        {
            return _context.TblSkinTypes.Any(e => e.Skintypeid == id);
        }
    }
}
