using DemoInterview.ViewModels;

namespace DemoInterview.Commands
{
    public class RefreshProductsCommand : AsyncCommandBase
    {
        private readonly ProductListingViewModel _productListingViewModel;

        public RefreshProductsCommand(ProductListingViewModel viewModel)
        {
            _productListingViewModel = viewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _productListingViewModel.SearchText = "";
            await _productListingViewModel.LoadProducts();
        }
    }
}
