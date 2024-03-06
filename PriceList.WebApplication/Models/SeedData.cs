using Microsoft.EntityFrameworkCore;

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
        if(!context.Products.Any())
        {
            //fill Products Table
            context.Products.AddRange(
                new Product { ProductName="Стул", ProductCategory = "Мебель", ProductDescription = "Обычный стул", ProductPrice = 1547.04m},
                new Product { ProductName = "Яблоко", ProductCategory = "Фрукты", ProductDescription = "Красное,наливное", ProductPrice = 196.67m},
                new Product { ProductName = "Слива", ProductCategory = "Фрукты", ProductDescription = "Спелая,садовая", ProductPrice =378.00m},
                new Product { ProductName = "Стол", ProductCategory = "Мебель", ProductDescription = "Для обеда в саду", ProductPrice =3098.39m},
                new Product { ProductName = "Груша", ProductCategory = "Фрукты", ProductDescription = "Можно скушать", ProductPrice =247.07m},
                new Product { ProductName = "Стол", ProductCategory = "Мебель", ProductDescription = "Компьтерный стол", ProductPrice =15999.98m}
                );
            context.SaveChanges();
        }
    }
}
