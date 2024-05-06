using Microsoft.EntityFrameworkCore;
using NorthwindModelClassLibrary;

namespace ProductsAPIService.Infrastructure
{
    public class ProductEfRepository : IRepository<Product>
    {
        ProductsDbContext dbContext;
        public ProductEfRepository( ProductsDbContext context) 
        {
            dbContext = context;
        }

        public void CreateNew(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return dbContext.Products.AsNoTracking().FirstOrDefault(c => c.ProductId == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
