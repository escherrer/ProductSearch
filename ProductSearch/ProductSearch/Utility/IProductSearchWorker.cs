namespace ProductSearch.Utility
{
    public interface IProductSearchWorker
    {
        void BeginSearch(string productName);

        void CancelSearch();
    }
}
