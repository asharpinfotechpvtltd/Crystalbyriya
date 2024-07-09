using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.ProductByConcern
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public CreateModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<int> AreChecked { get; set; }

        public IActionResult OnGet()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                ConcernList = _context.TblConcerns.Select(a => new
             SelectListItem
                {
                    Text = a.Concern,
                    Value = a.Id.ToString()
                }).ToList();

                var vm = new ConcernViewModel { ConcernList = ConcernList };

                return Page();
            }
        }

        public List<SelectListItem> ConcernList { get; set; }

        [BindProperty]
        public TblProductByConcern TblProductByConcern { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(ConcernViewModel model,string SkuCode)
        {
            var concerns = model.ConcernList.Where(x => x.Selected).Select(y => y.Value);

            foreach (var item in concerns)
            {
                TblProductByConcern concern = new TblProductByConcern();

                concern.SkuCode = SkuCode;
                concern.ConcernId = Convert.ToInt32(item.ToString());
                
                _context.TblProductByConcerns.Add(concern);
                await _context.SaveChangesAsync();

            }
             
            

         

            return RedirectToPage("./Index");
        }
    }
}
