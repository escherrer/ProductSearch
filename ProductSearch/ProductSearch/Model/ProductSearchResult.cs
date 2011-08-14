using System;

namespace ProductSearch.Model
{
    public class ProductSearchResult
    {
        public Uri ImageUri { get; private set; }
        public decimal? Price { get; private set; }

        public ProductSearchResult(Uri imageUri, decimal? price)
        {
            ImageUri = imageUri;
            Price = price;
        }
    }
}