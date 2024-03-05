namespace PriceList.WebApplication.Models;

public class EFStoreRepository: IStoreRepository
{
    private PredpriyatieDbContext context;
    public EFStoreRepository(PredpriyatieDbContext ctx)
    {
        context = ctx;
    }
    public IQueryable<Product> Products => context.Products;
}
