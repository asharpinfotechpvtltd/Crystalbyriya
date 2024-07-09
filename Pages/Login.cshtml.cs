using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Astaberry.Pages
{
    public class LoginModel : PageModel
    {
        public ApplicationDbContext Context;
        public LoginModel(ApplicationDbContext _Context)
        {
            Context = _Context;

        }
        public void OnGet()
        {

        }
        public Admins Admin { get; set; }
        public async Task<IActionResult> OnPostLogin(string name,string Password)
        {
            Admins Admins =await Context.Admins.FirstOrDefaultAsync(uname => uname.EmailId == name && uname.Password == Password);
            if(Admins!=null)
            {
                HttpContext.Session.SetString("Login", name);
                return RedirectToPage("/Index", new { area = "Admin" });
            }
            else
            {
              return  Redirect("Login");
            }
        }
    }
}
