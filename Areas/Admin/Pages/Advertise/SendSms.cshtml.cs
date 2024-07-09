using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astaberry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Astaberry.Areas.Admin.Pages.Advertise
{
    public class SendSmsModel : PageModel
    {
        readonly ApplicationDbContext context;
        public SendSmsModel(ApplicationDbContext _context)
        {
            context = _context;
        }

        [BindProperty]
        public IEnumerable<TblRegister> Registers { get; set; }
        public async Task<IActionResult> OnPost(string message)
        {


            Registers = await List();
            foreach (var item in Registers)
            {
                double number = item.ContactNo;
            }

            return Page();
        }

        public async Task<List<TblRegister>> List()
        {
            return await context.TblRegisters.ToListAsync();
        }
        public void OnGet()
        {
        }
    }
}
