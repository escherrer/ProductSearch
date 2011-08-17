using System;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public class ProductSearchManager : IProductSearchManager
    {
        private ProductSearchWorker _productSearchWorker;
        
        public void DoSearch(string productName, IProductSearchRepository<Product> repo)
        {
            if (_productSearchWorker != null)
                _productSearchWorker.CancelSearch();

            _productSearchWorker = new ProductSearchWorker(repo, ProcessSearchResult, productName);
        }

        public event Action<ProductSearchResult> ResultsRecieved;

        private void ProcessSearchResult(ProductSearchResult result, IProductSearchWorker worker)
        {
            if (!result.IsCancelled)
            {
                if (ResultsRecieved != null)
                    ResultsRecieved(result);
            }

            worker.Dispose();
        }
    }
}
