using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;
using ProductSearch.Utility;

namespace ProductSearch.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ProductSearchManager _productSearchManager;
        private readonly IProductSearchRepository _productSearchRepository;
        private const string SearchResultDisplayError = "* Error displaying results.";
        private const string SearchResultRetrievalError = "* Error retrieving results.";
        private const string SearchResultCriteriaError = "* Please enter a valid product name.";
        private const string NoResults = "* No products found matching criteria.";
        private static readonly Uri BlankImage = new Uri("Images/blank_image.jpg", UriKind.Relative);
        private static readonly Uri NoImage = new Uri("Images/no_image.jpg", UriKind.Relative);
        private static readonly Uri InvalidImage = new Uri("Images/invalid_image.jpg", UriKind.Relative);

        public MainWindowViewModel()
        {
            SearchCommand = new RelayCommand<string>(DoSearch);

            _productSearchManager = new ProductSearchManager();
            _productSearchManager.ResultsRecieved += ProductSearchManagerResultsRecieved;

            _productSearchRepository = new BestBuyProductRepository();

            ProductImage = BlankImage;
        }

        public decimal? ProductPrice { get; set; }

        public Uri ProductImage { get; set; }

        public bool IsSearching { get; set; }

        public string ErrorMessage { get; set; }

        public RelayCommand<string> SearchCommand { get; private set; }

        private void DoSearch(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                ErrorMessage = SearchResultCriteriaError;
            }
            else
            {
                ProductImage = BlankImage;
                ProductPrice = null;
                ErrorMessage = string.Empty;

                IsSearching = true;
                _productSearchManager.DoSearch(productName, _productSearchRepository);
            }

            RefreshUi();
        }

        private void RefreshUi()
        {
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => IsSearching));
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => ProductImage));
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => ProductPrice));
            RaisePropertyChanged(ReflectionHelper.GetPropertyName(() => ErrorMessage));
        }

        private void ProductSearchManagerResultsRecieved(ProductSearchResult result)
        {
            if (result.HasError)
            {
                ErrorMessage = SearchResultRetrievalError;
            }
            else if (result.Product == null)
            {
                ErrorMessage = NoResults;
            }
            else
            {
                try
                {
                    ErrorMessage = string.Empty;
                    ProductPrice = decimal.Parse(result.Product.SalePrice);
                    ProductImage = SetProductImage(result.Product.imageUrl);
                }
                catch
                {
                    ErrorMessage = SearchResultDisplayError;
                }
            }

            IsSearching = false;

            RefreshUi();
        }

        private static Uri SetProductImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return NoImage;
            }

            try
            {
                return new Uri(imageUrl);
            }
            catch
            {
                return InvalidImage;
            }
        }
    }
}
