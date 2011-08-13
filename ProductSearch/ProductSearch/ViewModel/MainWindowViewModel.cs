using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProductSearch.Utility;

namespace ProductSearch.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            SearchCommand = new RelayCommand<string>(DoSearch);

            // Test
            ProductImage = new Uri("http://images.bestbuy.com/BestBuy_US/images/products/9321/9321245_sc.jpg");
            ErrorMessage = "* Unable to blah blah blah.";
            ProductPrice = 25.55m;
            IsSearching = true;
        }

        public decimal? ProductPrice { get; set; }

        public Uri ProductImage { get; set; }

        public bool IsSearching { get; set; }

        public string ErrorMessage { get; set; }

        public RelayCommand<string> SearchCommand { get; private set; }

        private void DoSearch(string productName)
        {

        }

        private void RefreshUi()
        {
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => IsSearching));
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => ProductImage));
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => ProductPrice));
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => ErrorMessage));
        }
    }
}
