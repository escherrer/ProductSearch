using GalaSoft.MvvmLight;
using ProductSearch.Utility;

namespace ProductSearch.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _isSearching;

        public decimal? ProductPrice
        {
            get { return 25.55m; }
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
    }
}
