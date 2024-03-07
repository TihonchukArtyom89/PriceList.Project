
namespace PriceList.WebApplication.Models.ViewModels;

public class ListOfPriceListsViewModels
{
    public IEnumerable<PriceList> PriceLists { get; set; } = Enumerable.Empty<PriceList>();
    public PagingInfo PagingInfo { get; set; } = new();
}
