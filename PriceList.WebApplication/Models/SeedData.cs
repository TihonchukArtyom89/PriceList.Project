using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            WriteLine("Exception message:\n" + ex.Message.ToString() + "Inner exception message:\n" + ex.InnerException?.Message);
        }
        if (!context.Products.Any())
        {
            string[] CategoryName = { "Мебель", "Фрукты" };
            if (!context.Categories.Any())
            {
                //code for insert sample data to table Categories(categories of product)//корректно передать кириллицу надо
                int num = context.Database.ExecuteSqlRaw("insert into Categories (CategoryName) values ('" + CategoryName[0] + "'), ('" + CategoryName[1] + "')");
                WriteLine("\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n" + num + "\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n");
                context.SaveChanges();
            }
            //get id from table Categoies
            var CategoryID_Мебель = context.Categories.Where(c => c.CategoryName == "Мебель").Select(c => c.CategoryID).ToQueryString();
            WriteLine("\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n" + CategoryID_Мебель + "\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n");
            //fill Products Table
            context.Products.AddRange(
                new Product { ProductName = "Стул", ProductDescription = "Обычный стул", ProductPrice = 1547.04m, CategoryID = 1 },
                new Product { ProductName = "Яблоко", ProductDescription = "Красное,наливное", ProductPrice = 196.67m, CategoryID = 2 },
                new Product { ProductName = "Слива", ProductDescription = "Спелая,садовая", ProductPrice = 378.00m, CategoryID = 2 },
                new Product { ProductName = "Стол", ProductDescription = "Для обеда в саду", ProductPrice = 3098.39m, CategoryID = 1 },
                new Product { ProductName = "Груша", ProductDescription = "Можно скушать", ProductPrice = 247.07m, CategoryID = 2 },
                new Product { ProductName = "Стол", ProductDescription = "Компьтерный стол", ProductPrice = 15999.98m, CategoryID = 1 }
                );
            context.SaveChanges();
        }
    }
}
