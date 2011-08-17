using System;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public interface IProductSearchManager
    {
        void DoSearch(string productName, IProductSearchRepository<Product> repo);

        event Action<ProductSearchResult> ResultsRecieved;
    }
}