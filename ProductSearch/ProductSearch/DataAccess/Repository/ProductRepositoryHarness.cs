using System;
using ProductSearch.Exceptions;
using ProductSearch.Model;
using ProductSearch.Utility;

namespace ProductSearch.DataAccess.Repository
{
    public class ProductRepositoryHarness : IProductSearchRepository<ProductSearchResult>, IDisposable
    {
        private IProductSearchRepository<Product> _repo;
        private static readonly Logger Log = new Logger(typeof(ProductRepositoryHarness));

        public ProductRepositoryHarness(IProductSearchRepository<Product> repo)
        {
            _repo = repo;
        }

        public ProductSearchResult Search(string criteria)
        {
            try
            {
                var result = _repo.Search(criteria);

                return new ProductSearchResult(false, false, result);
            }
            catch (DataAccessException e)
            {
                Log.Error("Search - Error.", e);                
                return new ProductSearchResult(false, true, null);
            }
        }

        public void Dispose()
        {
            _repo = null;
        }
    }
}
