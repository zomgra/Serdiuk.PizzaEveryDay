using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serdiuk.PizzaEveryDay.IdentityServer.Data;
using Serdiuk.PizzaEveryDay.IdentityServer.Entities;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(b =>
{
    b.AddDefaultPolicy(d =>
    {
        d.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddDbContext<AuthDbContext>(config =>
{
    config.UseInMemoryDatabase("MEMORY");
})
                .AddIdentity<ApplicationUser, ApplicationRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>()
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources())
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources())
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes())
    .AddInMemoryClients(IdentityConfiguration.Clients())
    .AddDeveloperSigningCredential();


builder.Services.AddAuthentication()
    .AddGoogle("google", opt =>
    {
        var googleAuth = Configuration.GetSection("Auth:Google");
        opt.ClientId = googleAuth["ClientId"];
        opt.ClientSecret = googleAuth["Secret"];
        opt.SignInScheme = IdentityConstants.ExternalScheme;
    });

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Auth/Login";
});
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

app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
