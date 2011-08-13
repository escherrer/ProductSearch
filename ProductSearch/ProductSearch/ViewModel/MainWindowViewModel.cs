using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProductSearch.Utility;

namespace ProductSearch.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _isSearching;

        public MainWindowViewModel()
        {
            SearchCommand = new RelayCommand<string>(DoSearch);
        }

        public decimal? ProductPrice
        {
            get { return 25.55m; }
        }

        public Uri ProductImage
        {
            get
            {
                return new Uri("http://images.bestbuy.com/BestBuy_US/images/products/9321/9321245_sc.jpg");
            }
        }

        public bool IsSearching
        {
            get { return _isSearching; }
            set
            {
                _isSearching = value; 
                RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => IsSearching));
            }
        }

        public RelayCommand<string> SearchCommand { get; private set; }

        private void DoSearch(string productName)
        {

        }
    }
}
