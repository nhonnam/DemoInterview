using DemoInterview.Services;
using DemoInterview.Stores;
using DemoInterview.ViewModels;
using System.ComponentModel;

namespace DemoInterview.Commands
{
    public class UpdateProductCommand : AsyncCommandBase
    {
        private readonly UpdateProductViewModel _updateProductViewModel;
        private readonly NavigationService _navigationService;
        private readonly ProductStore _productStore;

        public UpdateProductCommand(UpdateProductViewModel updateProductViewModel, NavigationService navigationService, ProductStore productStore)
        {
            _updateProductViewModel = updateProductViewModel;
            _navigationService = navigationService;
            _updateProductViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _productStore = productStore;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_updateProductViewModel.Name) &&
                _updateProductViewModel.Price > 0 &&
                base.CanExecute(parameter);
        }

        public override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateProductViewModel.Name) ||
                e.PropertyName == nameof(CreateProductViewModel.Price))

            {
                OnCanExecuteChanged();
            }
        }
    }
}
