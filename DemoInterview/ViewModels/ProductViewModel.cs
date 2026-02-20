using DemoInterview.Models;

namespace DemoInterview.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly Product _product;

        public int Id => _product.Id;
        public string? Name => _product.Name;
        public double Price => _product.Price;

        public ProductViewModel(Product product)
        {
            _product = product;
        }
    }
}
