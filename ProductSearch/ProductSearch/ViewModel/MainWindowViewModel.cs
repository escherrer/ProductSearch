using GalaSoft.MvvmLight;
using ProductSearch.Utility;

namespace ProductSearch.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _isSearching;

        public string SearchStatus
        {
            get
            {
                return IsSearching ? "Searching..." : "Search";
            }
        }

        private bool IsSearching
        {
            get { return _isSearching; }
            set
            {
                _isSearching = value; 
                RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => SearchStatus));
            }
        }

    }
}
