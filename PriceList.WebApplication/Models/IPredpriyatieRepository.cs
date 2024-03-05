namespace PriceList.WebApplication.Models;

public interface IPredpriyatieRepository
{
    IQueryable<PriceList> PriceLists { get; }
}
