using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Data;
using MyWebSite.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("MyWebSiteContextSqlite");
// builder.Services.AddDbContext<MyWebSiteContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MyWebSiteContext")));

builder.Services.AddDbContext<MyWebSiteContext>(options =>
    options.UseSqlite(ConnectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<MyWebSiteContext>();
builder.Services.AddDbContext<MyWebSiteContext>(options =>
    options.UseSqlite(ConnectionString));
/*builder.Services.AddDbContext<MyWebSiteContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MyWebSiteContextMySQL"), new MySqlServerVersion(new Version(8, 0, 22))));*/

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
/*app.UseEndpoints(endpoints => {
    endpoints.MapDynamicControllerRoute<TranslationTransformer>("{language}/{controller}/{action}");
});*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
