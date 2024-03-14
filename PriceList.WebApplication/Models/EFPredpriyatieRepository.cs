namespace PriceList.WebApplication.Models;

public class EFPredpriyatieRepository:IPredpriyatieRepository
{
    private PredpriyatieDbContext context;
    public EFPredpriyatieRepository(PredpriyatieDbContext _context)
    {
        context = _context;
    }

    public IQueryable<PriceList> PriceLists => context.PriceLists;
}
