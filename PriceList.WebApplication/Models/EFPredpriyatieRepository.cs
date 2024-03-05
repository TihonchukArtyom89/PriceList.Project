namespace PriceList.WebApplication.Models;

public class EFPredpriyatieRepository
{
    private PredpriyatieDbContext context;
    public EFPredpriyatieRepository(PredpriyatieDbContext ctx)
    {
        context = ctx;
    }

    public IQueryable<PriceList> PriceLists => context.PriceLists;
}
