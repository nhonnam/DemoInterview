using DemoInterview.Services;

namespace DemoInterview.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                _navigationService.Navigate(parameter);
            }
            else
            {
                _navigationService.Navigate();
            }
        }
    }
}
