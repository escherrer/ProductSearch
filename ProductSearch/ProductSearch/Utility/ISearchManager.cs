using ProductSearch.Model;

namespace ProductSearch.Utility
{
    public interface ISearchManager
    {
        void ProcessSearchResults(ProductSearchResult results);
    }
}