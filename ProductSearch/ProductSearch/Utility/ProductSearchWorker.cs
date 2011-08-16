using System;
using System.ComponentModel;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public class ProductSearchWorker : IProductSearchWorker
    {
        private static readonly Logger Log = new Logger(typeof(ProductSearchWorker));
        private readonly IProductSearchRepository _repo;
        private readonly Action<ProductSearchResult> _callback;
        private BackgroundWorker _searchWorker;

        public ProductSearchWorker(IProductSearchRepository repo, Action<ProductSearchResult> callback, string productName)
        {
            _repo = repo;
            _callback = callback;

            BeginSearch(productName);
        }

        private void BeginSearch(string productName)
        {            
            _searchWorker = new BackgroundWorker {WorkerSupportsCancellation = true};
            _searchWorker.DoWork += SearchWorkerDoWork;
            _searchWorker.RunWorkerCompleted += SearchWorkerCompleted;

            _searchWorker.RunWorkerAsync(productName);
        }

        public void CancelSearch()
        {
            _searchWorker.CancelAsync();
        }

        private void SearchWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                _callback.Invoke(new ProductSearchResult(true, false, null));
            }
            else
            {
                var result = (ProductSearchResult)e.Result;
                _callback.Invoke(result);   
            }
        }

        private void SearchWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            ProductSearchResult result = null;
            
            try
            {
                var productName = (string)e.Argument;

                result = _repo.Search(productName);
            }
            catch (Exception ex)
            {
                Log.Error("SearchWorkerDoWork - Error.", ex);

                result = new ProductSearchResult(false, true, null);
            }
            finally
            {
                if (((BackgroundWorker)sender).CancellationPending)
                    e.Cancel = true;

                e.Result = result;
            }
        }
    }
}
