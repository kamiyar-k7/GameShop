using Application.Services.implements;
using Application.Services.Interfaces;
using Data.Repository.AccountRepositories;
using Data.ShopDbcontext;
using Domain.IRepository.AccountRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region ioc Container
// sign up
builder.Services.AddScoped<ISignUpRepository , SignUpRepository>();
builder.Services.AddScoped<iSignUpService , SignUpService>();


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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion

