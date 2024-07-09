
using Astaberry.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(40);
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 300 * 1024 * 1024;
});

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("CrystalByRiyaConnection"))

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

//var options = new RewriteOptions();
//options.AddRedirectToHttps();
//options.Rules.Add(new RedirectToWwwRule());
//app.UseRewriter(options);

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseStatusCodePagesWithReExecute("/NotFound");
app.UseCors(MyAllowSpecificOrigins);
app.UseMvc();
app.UseMvcWithDefaultRoute();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

