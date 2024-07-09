using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.ProductDetail
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public CreateModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<SelectListItem> BrandOptions { get; set; }

        [BindProperty]
        public List<SelectListItem> RangeOptions { get; set; }
        
        [BindProperty]
        public List<SelectListItem> SkinType { get; set; }


        public IActionResult OnGet()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                CategoryOptions = _context.TblCategories.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.Categoryid.ToString(),
                                     Text = a.Categoryname
                                 }).ToList();

                SubCategoryOptions = _context.TblSubCategories.Select(a =>
                                     new SelectListItem
                                     {
                                         Value = a.SubCategoryId.ToString(),
                                         Text = a.SubCategoryName
                                     }).ToList();

                BrandOptions = _context.TblBrands.Select(a =>
                                       new SelectListItem
                                       {
                                           Value = a.Brandid.ToString(),
                                           Text = a.Brandname
                                       }).ToList();

                RangeOptions = _context.TblRange.Select(a =>
                                       new SelectListItem
                                       {
                                           Value = a.Id.ToString(),
                                           Text = a.Range
                                       }).ToList();

                SkinType = _context.TblSkinTypes.Select(a =>
                                        new SelectListItem
                                        {
                                            Value = a.Skintypeid.ToString(),
                                            Text = a.Skintypename
                                        }).ToList();
                return Page();
            }
        }

        [BindProperty]
        public TblProductDesc TblProductDesc { get; set; }
        
        [BindProperty]
        public TblCategory Tblcategory { get; set; }

        [BindProperty]
        public List<SelectListItem> CategoryOptions { get; set; }

        [BindProperty]
        public TblSubCategory TblSubcategory { get; set; }
        public List<SelectListItem> SubCategoryOptions { get; set; }



        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string LongDesc)
        {


            TblProductDesc.LongDesc = LongDesc;                
            _context.TblProductsDesc.Add(TblProductDesc);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
