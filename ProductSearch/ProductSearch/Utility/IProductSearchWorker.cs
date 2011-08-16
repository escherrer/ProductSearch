using System;

namespace ProductSearch.Utility
{
    public interface IProductSearchWorker :  IDisposable
    {
        void CancelSearch();
    }
}
