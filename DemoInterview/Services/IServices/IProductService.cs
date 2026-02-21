using DemoInterview.Models;

namespace DemoInterview.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}
