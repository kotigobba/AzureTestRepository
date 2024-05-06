using Microsoft.EntityFrameworkCore;
using NorthwindModelClassLibrary;

namespace ProductsAPIService.Infrastructure
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } 

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }
    }
}
