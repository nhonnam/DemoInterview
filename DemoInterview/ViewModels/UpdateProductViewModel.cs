using DemoInterview.Commands;
using DemoInterview.Services;
using DemoInterview.Stores;
using System.Windows.Input;

namespace DemoInterview.ViewModels
{
    public class UpdateProductViewModel : ViewModelBase
    {
        private int _id;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _price;

        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public UpdateProductViewModel(ProductViewModel productViewModel, NavigationService navigationService, ProductStore productStore)
        {
            Id = productViewModel.Id;
            Name = productViewModel.Name;
            Price = productViewModel.Price;

            SaveCommand = new UpdateProductCommand(this, productStore);
            BackCommand = new NavigateCommand(navigationService);
            DeleteProductCommand = new DeleteProductCommand(navigationService, productStore);
        }
    }
}
