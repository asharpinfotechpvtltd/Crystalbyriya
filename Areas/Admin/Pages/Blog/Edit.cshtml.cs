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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Astaberry.Areas.Admin.Pages.Blog
{
    public class EditModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(Astaberry.Models.ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        [BindProperty]
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

        public IFormFile Image { get; set; }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id,string Image,string BlogTitle, string Blogdescription, int Date, string Author, string Category, string Month, int Year)
        {
            var file = Path.Combine(webHostEnvironment.WebRootPath, "img/blog", Image);
            //using (var fileStream = new FileStream(file, FileMode.Create))
            //{
            //    await Image.CopyToAsync(fileStream);
            //}
            TblBlog = await _context.TblBlogs.FindAsync(id);
            TblBlog.Author = Author;
            TblBlog.Blogdescription = Blogdescription;
            TblBlog.BlogTitle = BlogTitle;
            TblBlog.Category = Category;
            TblBlog.Date = Date;
            TblBlog.Image = Image;
            

            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBlogExists(TblBlog.Blogid))
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

        private bool TblBlogExists(int id)
        {
            return _context.TblBlogs.Any(e => e.Blogid == id);
        }
    }
}
