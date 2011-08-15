using System.Windows;
using ProductSearch.ViewModel;

namespace ProductSearch.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            var mainWindowViewModel = new MainWindowViewModel();

            DataContext = mainWindowViewModel;

            Loaded += (sender, e) => txtProductName.Focus();
        }
    }
}
