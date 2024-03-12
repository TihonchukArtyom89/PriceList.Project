using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Linq;

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
            //Create data to insert in table
            Category c1 = new() { CategoryID = 1, CategoryName = "Мебель" };
            Category c2 = new() { CategoryID = 2, CategoryName = "Фрукты" };
            //Get connection to database
            DbConnection connectionDb = context.Database.GetDbConnection();
            string connectionString = connectionDb.ConnectionString;
            //connectionDb.Dispose();
            using (PredpriyatieDataContext dataContext = new(connectionString: connectionString))
            {
                dataContext.Connection.Open();
                using (var transaction = dataContext.Connection.BeginTransaction() )//connectionDb.BeginTransaction())
                {
                    //Set IDENTITY INSERT ON - to insert data in Categories table with custom id parameter
                    string tableName = "Categories";
                    string sqlCommandText = $"SET IDENTITY_INSERT {tableName} ON";
                    SqlCommand sqlCommand = new(
                        cmdText: sqlCommandText,
                        connection: (SqlConnection)connectionDb, //dataContext.Connection,
                        transaction: (SqlTransaction)transaction
                        );//неявное приведение типов - обращать внимание
                    sqlCommand.ExecuteNonQuery();
                    //Insert data in Categories table
                    context.Categories.AddRange(c1, c2);
                    context.SaveChanges();
                    //Set IDENTITY INSERT OFF - to autoincrement id parameter in table Categories
                    sqlCommandText = $"SET IDENTITY_INSERT {tableName} OFF";
                    sqlCommand.CommandText = sqlCommandText;
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            //Category[] categories=new Category[] { };
            //Category c1 = new() { CategoryID = 1, CategoryName = "Мебель" };
            //Category c2 = new() { CategoryID = 2, CategoryName = "Фрукты" };
            //fill Categories Table
            //context.Categories.AddRange(c1, c2);
            //context.Categories.AddRange(c1 = AddCategoryValue("Мебель",app),c2 = AddCategoryValue("Фрукты", app));
            //string[] categoryNames = new string[] { "Мебель", "Фрукты" };
            //Category c = new();
            //c.CategoryID = 0;
            //for(int i=0; i<categoryNames.Length; i++) 
            //{
            //    c.CategoryID = i + 1;
            //    c.CategoryName = categoryNames[i];
            //    context.Add(c);
            //    context.SaveChanges();
            //    WriteLine("\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n" + c.CategoryID + "\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n" + c.CategoryName + "\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
            //    categories[i] = c;
            //}
            //context.SaveChanges();
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
    //private static Category AddCategoryValue(string CategoryName, IApplicationBuilder app)
    //{
    //    PredpriyatieDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PredpriyatieDbContext>();
    //    Category c = new();
    //    c.CategoryID = 0;
    //    c.CategoryName = CategoryName;
    //    context.Categories.Add(c);
    //    context.SaveChanges();
    //    return c;
    //}
}
