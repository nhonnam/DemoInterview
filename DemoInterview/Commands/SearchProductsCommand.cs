using DemoInterview.Models;
using DemoInterview.Stores;
using DemoInterview.ViewModels;

namespace DemoInterview.Commands
{
    public class SearchProductsCommand : AsyncCommandBase
    {
        private readonly ProductListingViewModel _productListingViewModel;
        private readonly ProductStore _productStore;

        public SearchProductsCommand(ProductListingViewModel productListingViewModel, ProductStore productStore)
        {
            _productListingViewModel = productListingViewModel;
            _productStore = productStore;
        }

        public override Task ExecuteAsync(object? parameter)
        {
            var products = _productStore.SearchProducts(_productListingViewModel.SearchText);

            _productListingViewModel.LoadProducts(products);

            return Task.CompletedTask;
        }
    }
}
