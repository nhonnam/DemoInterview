using DemoInterview.DbContexts;
using DemoInterview.Models;
using DemoInterview.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace DemoInterview.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContextFactory _appDbContextFactory;

        public ProductService(AppDbContextFactory appDbContextFactory)
        {
            _appDbContextFactory = appDbContextFactory;
        }

        public async Task CreateProduct(Product product)
        {
            using AppDbContext context = _appDbContextFactory.CreateDbContext();
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }     

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using AppDbContext context = _appDbContextFactory.CreateDbContext();
            return await context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            using AppDbContext context = _appDbContextFactory.CreateDbContext();
            //Product? existing = await context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            //if (existing == null)
            //    throw new Exception("Product not found");

            //existing.Name = product.Name;
            //existing.Price = product.Price;
            context.Products.Update(product);

            await context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            using AppDbContext context = _appDbContextFactory.CreateDbContext();
            await context.Products.Where(p => p.Id == productId).ExecuteDeleteAsync();
        }
    }
}
