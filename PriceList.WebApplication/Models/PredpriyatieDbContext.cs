using Microsoft.EntityFrameworkCore;
using PriceList.WebApplication.Models;

namespace PriceList.WebApplication.Models;

public class PredpriyatieDbContext : DbContext
{
    public PredpriyatieDbContext(DbContextOptions<PredpriyatieDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<PriceList> PriceLists => Set<PriceList>();
    public DbSet<PriceListProduct> PriceListProducts => Set<PriceListProduct>();
    public DbSet<OptionalParameter> OptionalParameters => Set<OptionalParameter>();
    public DbSet<PriceListOptionalParameter> PriceListOptionalParameters => Set<PriceListOptionalParameter>();
}
