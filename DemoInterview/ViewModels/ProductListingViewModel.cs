using DemoInterview.Commands;
using DemoInterview.Services;
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
        public ICommand EditProductCommand { get; }

        private ProductViewModel? _selectedProduct;

        public ProductViewModel? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public ProductListingViewModel(NavigationService createNavigationService, NavigationService updateNavigationService, ProductStore productStore)
        {
            _productStore = productStore;
            _products = new ObservableCollection<ProductViewModel>();

            CreateProductCommand = new NavigateCommand(createNavigationService);
            EditProductCommand = new NavigateCommand(updateNavigationService);

            //_products.Add(new ProductViewModel(new Product("Nhon Nam", 22.9)));
            //_products.Add(new ProductViewModel(new Product("Banh Bu", 52.3)));
            //_products.Add(new ProductViewModel(new Product("Meo Meo", 2.3)));

            _ = UpdateProduct();
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
