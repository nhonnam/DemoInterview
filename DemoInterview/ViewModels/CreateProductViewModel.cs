using DemoInterview.Commands;
using DemoInterview.Services;
using DemoInterview.Stores;
using System.Windows.Input;

namespace DemoInterview.ViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateProductViewModel(NavigationService navigationService, ProductStore productStore)
        {
            SubmitCommand = new CreateProductCommand(this, navigationService, productStore);
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
