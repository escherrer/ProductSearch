using Remix;

namespace ProductSearch.Model
{
    public class ProductSearchResult
    {
        public bool IsCancelled { get; set; }
        public bool HasError { get; private set; }
        public Product Product { get; private set; }

        public ProductSearchResult(bool isCancelled, bool hasError, Product product)
        {
            IsCancelled = isCancelled;
            HasError = hasError;
            Product = product;
        }
    }
}