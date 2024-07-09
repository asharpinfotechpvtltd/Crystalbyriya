using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Astaberry.Areas.Admin.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CreateModel(Astaberry.Models.ApplicationDbContext context,IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public TblBlog TblBlog { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile Image,IFormFile thumbnail)
        {
            var file = Path.Combine(webHostEnvironment.WebRootPath, "img/blog", Image.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            var thumbnailimg = Path.Combine(webHostEnvironment.WebRootPath, "img/blog", thumbnail.FileName);
            using(var filestream=new FileStream(thumbnailimg,FileMode.Create))
            {
                await thumbnail.CopyToAsync(filestream);
            }
          
            TblBlog.Image = Image.FileName;
            TblBlog.ThumbnailImage = thumbnail.FileName;
            _context.TblBlogs.Add(TblBlog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
