﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Cities
{
    public class DetailsModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public DetailsModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public TblCities TblCities { get; set; }

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

                TblCities = await _context.TblCities.FirstOrDefaultAsync(m => m.Id == id);

                if (TblCities == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }
}