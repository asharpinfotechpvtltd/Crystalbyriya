using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class MenuViewModel
    {
        ApplicationDbContext context;

        public MenuViewModel(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<USERBYMENU> Menu { get; set; }

        
        private async Task<IEnumerable<USERBYMENU>> GetUserMenu(string Email)
        {

            var Skucode = new SqlParameter("@USEREMAIL", "AchalArya@astaberry.com");
            var result = await context.USERBYMENU.FromSqlRaw("USERBYMENU @USEREMAIL", Skucode).ToListAsync();


            Menu = result;
            return Menu;
        }
    }
}
