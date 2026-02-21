using DemoInterview.Models;

namespace DemoInterview.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly Product _product;

        public int Id => _product.Id;
        public string Name => _product.Name ?? "";
        public string Price => _product.Price.ToString();

        public ProductViewModel(Product product)
        {
            _product = product;
        }
    }
}
