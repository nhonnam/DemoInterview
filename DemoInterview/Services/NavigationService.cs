using DemoInterview.Stores;
using DemoInterview.ViewModels;

namespace DemoInterview.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;
        private readonly Func<object, ViewModelBase> _createViewModelWithParam;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public NavigationService(NavigationStore navigationStore, Func<object, ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModelWithParam = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }

        public void Navigate(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModelWithParam(parameter);
        }
    }
}
