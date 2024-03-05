using Microsoft.EntityFrameworkCore;

namespace PriceList.WebApplication.Models;

public class PredpriyatieDbContext : DbContext
{
    public PredpriyatieDbContext(DbContextOptions<PredpriyatieDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<PriceList> PriceLists => Set<PriceList>();
}
