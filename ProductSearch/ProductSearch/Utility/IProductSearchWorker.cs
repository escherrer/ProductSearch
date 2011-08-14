namespace ProductSearch.Utility
{
    public interface IProductSearchWorker
    {
        void BeginSearch(string productName);

        void CancelSearch();
    }

    //public class ProductSearchResult : IAsyncResult
    //{
    //    public bool HasError { get; private set; }
    //    public string ImageUrl { get; private set; }
    //    public decimal? Price { get; private set; }

    //    public ProductSearchResult(bool hasError, string imageUrl, decimal? price)
    //    {
    //        HasError = hasError;
    //        ImageUrl = imageUrl;
    //        Price = price;
    //    }

    //    public bool IsCompleted
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public WaitHandle AsyncWaitHandle
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public object AsyncState
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public bool CompletedSynchronously
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}
}
