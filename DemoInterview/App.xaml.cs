using DemoInterview.DbContexts;
using DemoInterview.Services;
using DemoInterview.Services.IServices;
using DemoInterview.Stores;
using DemoInterview.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace DemoInterview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Server=(localdb)\\MSSQLLocalDB;Database=DemoInterview;Trusted_Connection=True;";
        private readonly NavigationStore _navigationStore;
        private readonly AppDbContextFactory _appDbContextFactory;
        private readonly IProductService _productService;
        private readonly ProductStore _productStore;

        public App()
        {
            _appDbContextFactory = new AppDbContextFactory(CONNECTION_STRING);
            IProductService productService = new ProductService(_appDbContextFactory);
            _navigationStore = new NavigationStore();
            _productService = new ProductService(_appDbContextFactory);
            _productStore = new ProductStore(_productService);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (AppDbContext dbContext = _appDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateProductListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private CreateProductViewModel CreateCreateProductViewModel()
        {
            return new CreateProductViewModel(new NavigationService(_navigationStore, CreateProductListingViewModel), _productStore);
        }

        private UpdateProductViewModel CreateUpdateProductViewModel(object parameter)
        {
            ProductViewModel productViewModel = (ProductViewModel)parameter;

            return new UpdateProductViewModel(productViewModel, new NavigationService(_navigationStore, CreateProductListingViewModel), _productStore);
        }

        private ProductListingViewModel CreateProductListingViewModel()
        {
            return new ProductListingViewModel(
                    new NavigationService(_navigationStore, CreateCreateProductViewModel), 
                    new NavigationService(_navigationStore, CreateUpdateProductViewModel), _productStore);
        }
    }
}
