using System;

namespace ProductSearch.Model
{
    public class ProductSearchResult
    {
        public bool HasError { get; private set; }
        public string ImageUrl { get; private set; }
        public decimal? Price { get; private set; }

        public ProductSearchResult(bool hasError, string imageUrl, decimal? price)
        {
            HasError = hasError;
            ImageUrl = imageUrl;
            Price = price;
        }
    }
}