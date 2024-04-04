using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using PriceList.WebApplication.Components;
using PriceList.WebApplication.Models;
using Xunit;

namespace PriceList.Tests;

public class NavigationMenuViewComponentTests
{
    //добавлять тесты для компонента представлений список категорий продуктов
    [Fact]
    public void Displays_Selected_Category()
    {
        //Arrange
        string selectedCategory = "Cat3";
        Mock<IStoreRepository> mockStoreRepository = new();
        mockStoreRepository.Setup(m => m.Products).Returns((new Product[]
        {
            new() { ProductID = 1, ProductName = "P1" , CategoryID = 1 },
            new() { ProductID = 2, ProductName = "P2" , CategoryID = 2 },
            new() { ProductID = 3, ProductName = "P3" , CategoryID = 1 },
            new() { ProductID = 4, ProductName = "P4" , CategoryID = 2 },
            new() { ProductID = 5, ProductName = "P5" , CategoryID = 3 }
        }).AsQueryable<Product>());
        mockStoreRepository.Setup(c => c.Categories).Returns((new Category[]
        {
            new() { CategoryName = "Cat1", CategoryID = 1 },
            new() { CategoryName = "Cat2", CategoryID = 2 },
            new() { CategoryName = "Cat3", CategoryID = 3 }
        }).AsQueryable<Category>());
        NavigationMenuViewComponent navCategoryList = new(mockStoreRepository.Object)
        {
            ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            }
        };
        navCategoryList.RouteData.Values["category"] = selectedCategory;
        //Act
        string? result = (string?)(navCategoryList.Invoke() as ViewComponentResult)?.ViewData?["SelectedCategory"];//get null??

        //Assert
        Assert.Equal(selectedCategory, result);
    }
}
