using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public DetailsModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public TblBlog TblBlog { get; set; }

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

                TblBlog = await _context.TblBlogs.FirstOrDefaultAsync(m => m.Blogid == id);

                if (TblBlog == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }
}
