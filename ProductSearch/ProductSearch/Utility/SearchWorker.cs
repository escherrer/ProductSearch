using System;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public class SearchWorker : ISearchWorker
    {
        private readonly Action<ProductSearchResult> _callback;
        private readonly IProductSearchRepository _repo;

        public SearchWorker(Action<ProductSearchResult> callback, IProductSearchRepository repo)
        {
            _callback = callback;
            _repo = repo;
        }

        public void Search(string criteria)
        {
            var result = _repo.Search(criteria);

            _callback.Invoke(result);
        }
    }
}   