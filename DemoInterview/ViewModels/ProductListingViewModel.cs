using DemoInterview.Commands;
using DemoInterview.Services;
using DemoInterview.Services.IServices;
using DemoInterview.Stores;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace DemoInterview.ViewModels
{
    public class ProductListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ProductViewModel> _products;
        private readonly ProductStore _productStore;

        public IEnumerable<ProductViewModel> Products => _products;
        public ICommand CreateProductCommand { get; }
        public ProductListingViewModel(NavigationService navigationService, ProductStore productStore)
        {
            _productStore = productStore;
            _products = new ObservableCollection<ProductViewModel>();

            CreateProductCommand = new NavigateCommand(navigationService);

            //_products.Add(new ProductViewModel(new Product("Nhon Nam", 22.9)));
            //_products.Add(new ProductViewModel(new Product("Banh Bu", 52.3)));
            //_products.Add(new ProductViewModel(new Product("Meo Meo", 2.3)));

            UpdateProduct().ConfigureAwait(false);
        }

        private async Task UpdateProduct()
        {

            try
            {
                await _productStore.Load();
                foreach (var product in _productStore.Products)
                {
                    ProductViewModel productViewModel = new(product);
                    _products.Add(productViewModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load products.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
