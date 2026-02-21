using DemoInterview.Models;
using DemoInterview.Stores;
using DemoInterview.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace DemoInterview.Commands
{
    public class UpdateProductCommand : AsyncCommandBase
    {
        private readonly UpdateProductViewModel _updateProductViewModel;
        private readonly ProductStore _productStore;

        public UpdateProductCommand(UpdateProductViewModel updateProductViewModel, ProductStore productStore)
        {
            _updateProductViewModel = updateProductViewModel;
            _updateProductViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _productStore = productStore;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(_updateProductViewModel.Name) &&
                double.TryParse(_updateProductViewModel.Price, out double price) &&
                price > 0 &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Product product = new(_updateProductViewModel.Id, _updateProductViewModel.Name, double.Parse(_updateProductViewModel.Price));

            try
            {
                await _productStore.UpdateProduct(product);
                MessageBox.Show("Updated product successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update product: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UpdateProductViewModel.Name) ||
                e.PropertyName == nameof(UpdateProductViewModel.Price))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
