using System;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;

namespace ProductSearch.Test.Mocks
{
    public class MockProductSearchRepository : IProductSearchRepository
    {
        public const string Error = "error";

        public ProductSearchResult Search(string criteria)
        {
            if (criteria == Error)
                throw new Exception("Mock error");

            return new ProductSearchResult(new Uri(string.Empty), 5.99m);
        }
    }
}
