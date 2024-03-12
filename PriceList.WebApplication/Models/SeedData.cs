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
            //code for insert sample data to table Categories(categories of product)
            ////Create data to insert in table
            Category c1 = new() { CategoryID = 1, CategoryName = "Мебель" };
            Category c2 = new() { CategoryID = 2, CategoryName = "Фрукты" };
            int num = context.Database.ExecuteSqlRaw("insert into Categories (CategoryName) values ('Мебель'), ('Фрукты')"); 
            ////Set IDENTITY INSERT ON - to insert data in Categories table with custom id parameter
            //int num = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories ON");
            //context.SaveChanges();
            //WriteLine("\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n"+num+"\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n");
            ////Insert data in Categories table
            //context.Categories.AddRange(c1, c2);
            //context.SaveChanges();
            ////Set IDENTITY INSERT OFF - to autoincrement id parameter in table Categories
            //num = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories OFF");
            WriteLine("\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n" + num + "\n\n\n\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n\n");
            context.SaveChanges();
            //fill Products Table            
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
