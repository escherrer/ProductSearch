using ProductSearch.Model;

namespace ProductSearch.DataAccess.Repository
{
    public interface IProductSearchRepository
    {
        ProductSearchResult Search(string criteria);
    }
}



