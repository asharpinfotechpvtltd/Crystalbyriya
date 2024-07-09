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

namespace Astaberry.Areas.Admin.Pages.ProductDetail
{
    public class EditModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public EditModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProductDesc TblProductDesc { get; set; }
        [BindProperty]
        public List<SelectListItem> BrandOptions { get; set; }

        [BindProperty]
        public List<SelectListItem> RangeOptions { get; set; }

        [BindProperty]
        public List<SelectListItem> SkinType { get; set; }
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

                TblProductDesc = await _context.TblProductsDesc.FirstOrDefaultAsync(m => m.Id == id);

                if (TblProductDesc == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }

       

        [BindProperty]
        public TblCategory Tblcategory { get; set; }

        [BindProperty]
        public List<SelectListItem> CategoryOptions { get; set; }

        [BindProperty]
        public TblSubCategory TblSubcategory { get; set; }
        public List<SelectListItem> SubCategoryOptions { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string Skucode, string ProductName, int Categoryid, int Subcategoryid, int BrandId, int Range, string ShortDesc, string LongDesc, int SkinType, string Metakeyword, string MetaDescription, double Gst, string CustomeUrl,string GroupName)
        {
            TblProductDesc desc = await _context.TblProductsDesc.SingleOrDefaultAsync(Sku => Sku.Skucode == Skucode);
            if(desc!=null)
            {
                desc.BrandId = BrandId;
                desc.Categoryid = Categoryid;
                desc.CustomeUrl = CustomeUrl;
                desc.Gst = Gst;
                desc.LongDesc = LongDesc;
                desc.MetaDescription = MetaDescription;
                desc.Metakeyword = Metakeyword;
                desc.ProductName = ProductName;
                desc.Range = Range;
                desc.ShortDesc = ShortDesc;
                desc.SkinType = SkinType;
                desc.Subcategoryid = Subcategoryid;
                desc.GroupName = GroupName;
            }
            

            _context.Attach(desc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductDescExists(TblProductDesc.Id))
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

        private bool TblProductDescExists(int id)
        {
            return _context.TblProductsDesc.Any(e => e.Id == id);
        }
    }
}
