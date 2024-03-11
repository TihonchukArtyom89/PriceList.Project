namespace PriceList.WebApplication.Models;

public class EFStoreRepository: IStoreRepository
{
    private PredpriyatieDbContext context;
    public EFStoreRepository(PredpriyatieDbContext ctx)
    {
        context = ctx;
    }
    public IQueryable<Product> Products => context.Products;
    public void CreateProduct(Product p)
    {
        context.Add(p);
        context.SaveChanges();
    }
    public void DeleteProduct(Product p)
    {
        context.Remove(p);
        context.SaveChanges();
    }
    public void SaveProduct(Product p)
    {
        context.SaveChanges();
    }
}
