using DemoInterview.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoInterview.Views
{
    /// <summary>
    /// Interaction logic for ProductListingView.xaml
    /// </summary>
    public partial class ProductListingView : UserControl
    {
        public ProductListingView()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is ProductListingViewModel viewModel &&
                viewModel.SelectedProduct != null)
            {
                viewModel.EditProductCommand.Execute(viewModel.SelectedProduct);
                Console.WriteLine(viewModel.SelectedProduct.Name);
            }
        }
    }
}
