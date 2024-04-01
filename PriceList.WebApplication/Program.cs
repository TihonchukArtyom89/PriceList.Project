using Microsoft.EntityFrameworkCore;
using PriceList.WebApplication.Models;  

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PredpriyatieDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:PriceList.WebApplicationConnection"]);});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IPredpriyatieRepository, EFPredpriyatieRepository>();
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();
//app.MapControllerRoute("pagination","Products/Page{productPage}", new { Controller = "Home",  action = "Index" });
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", Action = "Index", productPage =1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("catpage", "category/Page{productPage:int}", new { Controller = "Home", Action = "Index", productPage = 1 });
//url scheme help
/*
/ выводит первую страницу списка продоктов со всех категорий
/Page2 показывает определённую страницу(в данном случае вторую) списка продуктов ото всех категорий 
/test показывает первую страницу элементов списка определённой категории (в данном случае это категория продуктов test)
/test/Page2 показывает определённую страницу(в данном случае вторую) списка продуктов определённой категории (в данном случае это категория продуктов test)
*/
app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);//fill db with sample data

app.Run();
