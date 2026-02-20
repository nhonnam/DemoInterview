using DemoInterview.Models;
using DemoInterview.Services;
using DemoInterview.Stores;
using DemoInterview.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace DemoInterview.Commands
{
    public class CreateProductCommand : AsyncCommandBase
    {
        private readonly CreateProductViewModel _createProductViewModel;
        private readonly NavigationService _navigationService;
        private readonly ProductStore _productStore;

        public CreateProductCommand(CreateProductViewModel createProductViewModel, NavigationService navigationService, ProductStore productStore)
        {
            _createProductViewModel = createProductViewModel;
            _navigationService = navigationService;
            _createProductViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _productStore = productStore;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_createProductViewModel.Name) &&
                _createProductViewModel.Price > 0 &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Product product = new(_createProductViewModel.Name, _createProductViewModel.Price);

            try
            {
                await _productStore.CreateProduct(product);
                MessageBox.Show("Created product successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _navigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
