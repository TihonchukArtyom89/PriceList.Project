//namespace PriceList.Tests;

//public class PriceListControllerTests
//{
//    [Fact]
//    public void Can_Use_Repository()
//    {
//        //Arrange
//        Mock<IPredpriyatieRepository> mockPredpriyatieRepository = new();
//        mockPredpriyatieRepository.Setup(m => m.PriceLists).Returns((new WebApplication.Models.PriceList[]
//        {
//            new() { PriceListID=1,PriceListName="PL1"},
//            new() { PriceListID=2,PriceListName="PL2"}
//        }).AsQueryable());
//        PriceListController priceListController = new(mockPredpriyatieRepository.Object);
//        //Act
//        IEnumerable<WebApplication.Models.PriceList>? resultPriceList = (priceListController.ListOfPriceList() as ViewResult)?.ViewData.Model as IEnumerable<WebApplication.Models.PriceList>;
//        //Assert
//        WebApplication.Models.PriceList[] priceListsArray = resultPriceList?.ToArray() ?? Array.Empty<WebApplication.Models.PriceList>();
//        Assert.True(priceListsArray.Length == 2);
//    }
//}