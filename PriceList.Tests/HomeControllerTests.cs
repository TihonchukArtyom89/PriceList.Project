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
        IEnumerable<Product>? resultProduct = (homeController.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
        //Assert
        Product[] productsArray = resultProduct?.ToArray() ?? Array.Empty<Product>();
        Assert.True(productsArray.Length == 2);
        Assert.Equal("P1", productsArray[0].ProductName);
        Assert.Equal("P2", productsArray[1].ProductName);
    }
}