using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace PriceList.WebApplication.Models;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        PredpriyatieDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PredpriyatieDbContext>();
        try
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message.ToString());
        }
        if (!context.Products.Any())
        {
            //Category c1 = , c2;
            Category c1 = new() { CategoryID = 1, CategoryName = "Мебель" };
            Category c2 = new() { CategoryID = 2, CategoryName = "Фрукты" };
            //fill Categories Table
            context.Categories.AddRange(c1, c2);
            //fill Products Table
            WriteLine("\n\n!!!!!!!!!!!!!!!!!!!!!!!!!\n\n" + c1.CategoryID + "\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n" + c2.CategoryID);
            context.Products.AddRange(
                new Product { ProductName = "Стул", ProductDescription = "Обычный стул", ProductPrice = 1547.04m, CategoryID = c1.CategoryID },
                new Product { ProductName = "Яблоко", ProductDescription = "Красное,наливное", ProductPrice = 196.67m, CategoryID = c2.CategoryID },
                new Product { ProductName = "Слива", ProductDescription = "Спелая,садовая", ProductPrice = 378.00m, CategoryID = c2.CategoryID },
                new Product { ProductName = "Стол", ProductDescription = "Для обеда в саду", ProductPrice = 3098.39m, CategoryID = c1.CategoryID },
                new Product { ProductName = "Груша", ProductDescription = "Можно скушать", ProductPrice = 247.07m, CategoryID = c2.CategoryID },
                new Product { ProductName = "Стол", ProductDescription = "Компьтерный стол", ProductPrice = 15999.98m, CategoryID = c1.CategoryID }
                );
            context.SaveChanges();
        }
    }
}
