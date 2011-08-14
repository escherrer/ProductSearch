using System;

namespace ProductSearch.Model
{
    public class ProductSearchResult
    {
        public bool WasCancelled { get; private set; }
        public bool HasError { get; private set; }
        public string ImageUrl { get; private set; }
        public decimal? Price { get; private set; }

        public ProductSearchResult(bool wasCancelled, bool hasError, string imageUrl, decimal? price)
        {
            WasCancelled = wasCancelled;
            HasError = hasError;
            ImageUrl = imageUrl;
            Price = price;
        }
    }
}