namespace ProductSearch.DataAccess.Repository
{
    public interface IProductSearchRepository<T>
    {
        T Search(string criteria);
    }
}



