using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using CrystalByRiya.Models;

namespace CrystalByRiya.Areas.Admin.Pages.MenuCollections
{
    public class DetailsModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public DetailsModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public MenuCollection MenuCollection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menucollection = await _context.TblMenuLists.FirstOrDefaultAsync(m => m.Id == id);
            if (menucollection == null)
            {
                return NotFound();
            }
            else
            {
                MenuCollection = menucollection;
            }
            return Page();
        }
    }
}
