using PriceList.WebApplication.Models.ViewModels;

namespace PriceList.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Can_Use_Repository()
    {
        //Arrange
        Mock<IStoreRepository> mockStoreRepository = new();
        mockStoreRepository.Setup(m => m.Products).Returns((new Product[]
        {
            new() { ProductID = 1, ProductName = "P1" },
            new() { ProductID = 2, ProductName = "P2" }
        }).AsQueryable());
        HomeController homeController = new(mockStoreRepository.Object);
        //Act
        ProductsListViewModels resultProduct = homeController.Index(null)?.ViewData.Model as ProductsListViewModels ?? new();
        //Assert
        Product[] productsArray = resultProduct.Products.ToArray();
        Assert.True(productsArray.Length == 2);
        Assert.Equal("P1", productsArray[0].ProductName);
        Assert.Equal("P2", productsArray[1].ProductName);
    }
    [Fact]
    public void Can_Paginate_List_Of_Products()
    {
        //Arrange
        Mock<IStoreRepository> mockStoreRepository = new();
        mockStoreRepository.Setup(m => m.Products).Returns((new Product[]
        {
            new() { ProductID = 1, ProductName = "P1" },
            new() { ProductID = 2, ProductName = "P2" },
            new() { ProductID = 3, ProductName = "P3" },
            new() { ProductID = 4, ProductName = "P4" },
            new() { ProductID = 5, ProductName = "P5" }
        }).AsQueryable());
        HomeController homeController = new(mockStoreRepository.Object) { PageSize = 3 };
        //Act
        ProductsListViewModels resultProduct = homeController.Index(null, 2)?.ViewData.Model as ProductsListViewModels ?? new();
        //Assert
        Product[] productsArray = resultProduct.Products.ToArray();
        Assert.True(productsArray.Length == 2);
        Assert.Equal("P4", productsArray[0].ProductName);
        Assert.Equal("P5", productsArray[1].ProductName);
    }
    [Fact]
    public void Can_Send_Pagination_View_Model()
    {
        //Arrange
        Mock<IStoreRepository> mockStoreRepository = new();
        mockStoreRepository.Setup(m => m.Products).Returns((new Product[]
        {
            new() { ProductID = 1, ProductName = "P1" },
            new() { ProductID = 2, ProductName = "P2" },
            new() { ProductID = 3, ProductName = "P3" },
            new() { ProductID = 4, ProductName = "P4" },
            new() { ProductID = 5, ProductName = "P5" }
        }).AsQueryable());
        HomeController homeController = new(mockStoreRepository.Object) { PageSize = 3 };
        //Act
        ProductsListViewModels resultProduct = homeController.Index(null, 2)?.ViewData.Model as ProductsListViewModels ?? new();
        //Assert
        PagingInfo pageIngo = resultProduct.PagingInfo;
        Assert.Equal(2, pageIngo.CurrentPage);
        Assert.Equal(3, pageIngo.ItemsPerPage);
        Assert.Equal(5, pageIngo.TotalItems);
        Assert.Equal(2, pageIngo.TotalPages);
    }
    [Fact]
    public void Can_Add_Invalid_Product()
    {
        //Arrange
        Product p1 = new() { ProductID = 1, ProductName = "P1", ProductDescription = "Description 1", ProductPrice = 2.9M, CategoryID = 3 };
        Mock<IStoreRepository> mockStoreRepository = new();
        HomeController homeController = new(mockStoreRepository.Object) { PageSize = 3 };
        homeController.ModelState.AddModelError("CategoryID", "Required");
        //Act
        IActionResult response = homeController.Create(p1);
        //Assert
        Assert.IsType<PartialViewResult>(response);
    }
    [Fact]
    public void Can_Add_Valid_Product()
    {
        //Arrange
        Product p1 = new() { ProductID = 1, ProductName = "P1", ProductDescription = "Description 1", ProductPrice = 2.9M, CategoryID = 3 };
        Mock<IStoreRepository> mockStoreRepository = new();
        HomeController homeController = new(mockStoreRepository.Object) { PageSize = 3 };
        //Act
        IActionResult response = homeController.Create(p1);
        //Assert
        Assert.IsType<RedirectToActionResult>(response);
    }
    [Fact]
    public void Can_Filter_Products()
    {
        //Arrange
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
        HomeController homeController = new(mockStoreRepository.Object) { PageSize = 3 };
        //Act     
        Product[] result = (homeController.Index("Cat2", 1)?.ViewData.Model as ProductsListViewModels ?? new()).Products.ToArray();
        //Assert
        Assert.Equal(2, result.Length);
        Assert.True(result[0].ProductName == "P2" && result[0].CategoryID == 2);
        Assert.True(result[1].ProductName == "P4" && result[1].CategoryID == 2);
    }
}