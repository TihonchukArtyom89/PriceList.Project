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
/ ������� ������ �������� ������ ��������� �� ���� ���������
/Page2 ���������� ����������� ��������(� ������ ������ ������) ������ ��������� ��� ���� ��������� 
/test ���������� ������ �������� ��������� ������ ����������� ��������� (� ������ ������ ��� ��������� ��������� test)
/test/Page2 ���������� ����������� ��������(� ������ ������ ������) ������ ��������� ����������� ��������� (� ������ ������ ��� ��������� ��������� test)
*/
app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);//fill db with sample data

app.Run();
