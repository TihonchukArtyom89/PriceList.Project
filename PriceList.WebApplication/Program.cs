using Microsoft.EntityFrameworkCore;
using PriceList.WebApplication.Models;  

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PredpriyatieDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:PriceList.WebApplicationConnection"]); });
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IPredpriyatieRepository, EFPredpriyatieRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute("pagination","Products/Page{productPage}", new { Controller = "Home",  action = "Index"  });
app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);//fill db with sample data

app.Run();
