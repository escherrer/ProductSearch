using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public interface IProductSearchManager
    {
        void DoSearch(string productName);
        void ProcessSearchResults(ProductSearchResult results);
    }
}