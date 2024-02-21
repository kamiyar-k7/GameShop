using Application.Services.implements;
using Application.Services.Interfaces;
using Data.Repository.AccountRepositories;
using Data.Repository.CatalogRepository;
using Data.Repository.GenreRepository;
using Data.Repository.HomeRepository;
using Data.Repository.Platformrepository;
using Data.Repository.StoreRepository;
using Data.ShopDbcontext;
using Domain.IRepository.AccountRepositories;
using Domain.IRepository.CatalogRepository;
using Domain.IRepository.GenreRepostoryInterface;
using Domain.IRepository.HomeRepositoryInterface;
using Domain.IRepository.PlatformRepositoryInterface;
using Domain.IRepository.StoreRepositoryInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region ioc Container
//Home
builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IHomeService, HomeService>();

// Store
builder.Services.AddScoped<IStoreRepositpory, StoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();

// catalog 
builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
builder.Services.AddScoped<ICatalogService, CatalogService>();

// Genre 
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();

// Platform
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IPlatformService, PlatformService>();

#region Account 
// sign up
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<ISignUpService, SignUpService>();
#endregion



#endregion

#region DbContext
builder.Services.AddDbContext<GameShopDbContext>(
    option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("GameShopDbContextConnectionString")));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion

