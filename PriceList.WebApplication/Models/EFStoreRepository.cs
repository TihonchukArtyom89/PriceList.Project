namespace PriceList.WebApplication.Models;

public class EFStoreRepository: IStoreRepository
{
    private PredpriyatieDbContext context;
    public EFStoreRepository(PredpriyatieDbContext _context)
    {
        context = _context;
    }
    public IQueryable<Product> Products => context.Products;
    public IQueryable<Category> Categories => context.Categories;
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
