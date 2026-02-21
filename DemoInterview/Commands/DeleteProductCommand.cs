using DemoInterview.Services;
using DemoInterview.Stores;
using System.ComponentModel;
using System.Windows;

namespace DemoInterview.Commands
{
    public class DeleteProductCommand : AsyncCommandBase
    {
        private readonly NavigationService _productListingNavigationService;
        private readonly ProductStore _productStore;

        public DeleteProductCommand(NavigationService productListingNavigationService, ProductStore productStore)
        {

            _productListingNavigationService = productListingNavigationService;
            _productStore = productStore;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to delete this product?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult != MessageBoxResult.Yes)
                return;

            int productId = (int)parameter;

            await _productStore.DeleteProduct(productId);

            _productListingNavigationService.Navigate();
        }
    }
}
