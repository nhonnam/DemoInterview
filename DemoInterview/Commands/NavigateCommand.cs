using DemoInterview.Services;

namespace DemoInterview.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _nagivationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _nagivationService = navigationService;
        }

        public override void Execute(object? parameter)
        {

            _nagivationService.Navigate();
        }
    }
}
