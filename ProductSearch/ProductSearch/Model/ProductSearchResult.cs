namespace ProductSearch.Model
{
    public class ProductSearchResult
    {
        public bool IsCancelled { get; set; }
        public bool HasError { get; private set; }
        public string ImageUrl { get; private set; }
        public decimal? Price { get; private set; }

        public ProductSearchResult(bool isCancelled, bool hasError, string imageUrl, decimal? price)
        {
            IsCancelled = isCancelled;
            HasError = hasError;
            ImageUrl = imageUrl;
            Price = price;
        }
    }
}