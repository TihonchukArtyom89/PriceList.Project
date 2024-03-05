using Microsoft.EntityFrameworkCore;
using PriceList.WebApplication.Models;  

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PredpriyatieDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:PriceList.WebApplicationConnection"]); });
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
//app.MapGet("/", () => "Hello World!");

app.Run();
