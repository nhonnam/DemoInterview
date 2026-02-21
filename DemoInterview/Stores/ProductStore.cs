using DemoInterview.Models;
using DemoInterview.Services.IServices;

namespace DemoInterview.Stores
{
    public class ProductStore
    {
        private readonly IProductService _productService;
        private readonly List<Product> _products;
        //private readonly ObservableCollection<Product> _products;
        private readonly Lazy<Task> _initializeLazy;

        public IEnumerable<Product> Products => _products;

        public ProductStore(IProductService productService)
        {
            _productService = productService;
            _initializeLazy = new Lazy<Task>(Initialize);
            _products = new List<Product>();
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        public async Task CreateProduct(Product product)
        {
            await _productService.CreateProduct(product);

            _products.Add(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productService.UpdateProduct(product);

            int index = _products.ToList().FindIndex(p => p.Id == product.Id);

            if (index >= 0)
            {
                _products[index] = product;
            }
        }

        public async Task DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);

            Product? product = _products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public async Task Initialize()
        {
            IEnumerable<Product> products = await _productService.GetAllProducts();

            _products.Clear();
            _products.AddRange(products);
        }
    }
}
