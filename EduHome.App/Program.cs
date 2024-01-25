using EduHome.Data.DAl;
using Microsoft.EntityFrameworkCore;
using EduHome.Data.ServiceRegisterations;
using EduHome.Core.Entities;
using Microsoft.AspNetCore.Identity;
using EduHomeServices.ExternalServices.Interface;
using EduHomeServices.ExternalServices.Implementations;
using EduHomeServices.Services.Interfaces;
using EduHomeServices.Services.Implementations;
using EduHome.Core.Repositories;
using EduHome.Data.Repositories;
using EduHomeServices.ServiceRegisterations;
using EduHome.Data;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllersWithViews();
builder.Services.DataAccessServiceRegister(builder.Configuration);
builder.Services.ServiceLayerServiceRegister();
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.SignIn.RequireConfirmedEmail = true;
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 5;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = false;


    opt.User.RequireUniqueEmail = false;

    opt.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm_-1234567890.QWERTYUIOPASDFGHJKLZXCVBNM:)( ";

    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
}).AddDefaultTokenProviders().AddEntityFrameworkStores<EduHomeDbContext>();


var app = builder.Build();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=index}/{id?}"
    );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

var scopFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    await DbInitializer.SeedAsync(roleManager, userManager);
}

app.Run();
