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
    public class IndexModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public IndexModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MenuCollection> MenuCollection { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MenuCollection = await _context.TblMenuLists.ToListAsync();
        }
    }
}
