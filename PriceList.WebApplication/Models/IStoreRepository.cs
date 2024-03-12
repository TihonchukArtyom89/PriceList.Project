namespace PriceList.WebApplication.Models;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }

    IQueryable<Category> Categories { get; }
    void SaveProduct(Product p);
    void CreateProduct(Product p);
    void DeleteProduct(Product p);
}
