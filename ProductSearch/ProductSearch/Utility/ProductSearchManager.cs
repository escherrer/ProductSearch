using System;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public class ProductSearchManager : IProductSearchManager
    {
        private ProductSearchWorker _productSearchWorker;
        
        public void DoSearch(string productName, IProductSearchRepository repo)
        {
            if (_productSearchWorker != null)
                _productSearchWorker.CancelSearch();

            _productSearchWorker = new ProductSearchWorker(repo, ProcessSearchResult);
            _productSearchWorker.BeginSearch(productName);
        }

        public event Action<ProductSearchResult> ResultsRecieved;

        private void ProcessSearchResult(ProductSearchResult result)
        {
            if (!result.IsCancelled)
            {
                if (ResultsRecieved != null)
                    ResultsRecieved(result);
            }
        }
    }
}
