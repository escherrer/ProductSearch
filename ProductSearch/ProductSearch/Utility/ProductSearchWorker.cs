using System;
using System.ComponentModel;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public class ProductSearchWorker : IProductSearchWorker
    {
        private readonly IProductSearchRepository _repo;
        private readonly Action<ProductSearchResult> _callback;
        private BackgroundWorker _searchWorker;

        public ProductSearchWorker(IProductSearchRepository repo, Action<ProductSearchResult> callback)
        {
            _repo = repo;
            _callback = callback;
        }

        public void BeginSearch(string productName)
        {
            _searchWorker = new BackgroundWorker();
            _searchWorker.DoWork += SearchWorkerDoWork;
            _searchWorker.RunWorkerCompleted += SearchWorkerCompleted;

            _searchWorker.RunWorkerAsync(productName);
        }

        public void CancelSearch()
        {
            if (_searchWorker != null)
                _searchWorker.CancelAsync();
        }

        private void SearchWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                _callback.Invoke((ProductSearchResult)e.Result);
            }
        }

        private void SearchWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var productName = (string)e.Argument;

            var result = _repo.Search(productName);

            e.Result = result;
        }
    }
}
