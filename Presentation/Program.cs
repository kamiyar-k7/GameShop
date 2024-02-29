using Application.Services.implements;
using Application.Services.Interfaces;
using Data.Repository.AccountRepositories;
using Data.Repository.CartRepository;
using Data.Repository.CatalogRepository;
using Data.Repository.GenreRepository;
using Data.Repository.HomeRepository;
using Data.Repository.Platformrepository;
using Data.Repository.ProductRepository;
using Data.Repository.StoreRepository;
using Data.ShopDbcontext;
using Domain.IRepository.AccountRepositorieInterfaces;
using Domain.IRepository.CartRepositoryInterface;
using Domain.IRepository.CatalogRepositoryInterface;
using Domain.IRepository.GenreRepostoryInterface;
using Domain.IRepository.HomeRepositoryInterface;
using Domain.IRepository.PlatformRepositoryInterface;
using Domain.IRepository.ProductRepositoryInterface;
using Domain.IRepository.StoreRepositoryInterface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region ioc Container
//Home
builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IHomeService, HomeService>();

#region Store part
// Store
builder.Services.AddScoped<IStoreRepositpory, StoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();

// catalog 
builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
builder.Services.AddScoped<ICatalogService, CatalogService>();

// Product 
builder.Services.AddScoped<IProductRepository , ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Genre 
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();

// Platform
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IPlatformService, PlatformService>();

#endregion



#region Account 
// sign up
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<ISignUpService, SignUpService>();

//Sign in
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<ISignInRepository , SignInRepository>();

// Cart 
builder.Services.AddScoped<ICartRepository , CartRepository>();
builder.Services.AddScoped<ICartService , CartService>();
#endregion



#endregion

#region DbContext
builder.Services.AddDbContext<GameShopDbContext>(
    option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("GameShopDbContextConnectionString")));
#endregion


#region cookies
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
         // Add Cookie settings
         .AddCookie(options =>
         {
             options.LoginPath = "/Account/Signin";
             options.LogoutPath = "/Signout";
             options.ExpireTimeSpan = TimeSpan.FromDays(30);
         });
#endregion


var app = builder.Build();

#region App Services
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
        name: "Areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});



//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion

