//using System;
//using System.Threading;
//using ProductSearch.DataAccess.Repository;
//using ProductSearch.Model;

//namespace ProductSearch.Test.Mocks
//{
//    public class MockProductSearchRepository : IProductSearchRepository
//    {
//        public const string Error = "error";

//        public ProductSearchResult Search(string criteria)
//        {
//            if (criteria == Error)
//                throw new Exception("Mock error");

//            var rand = new Random();

//            Thread.Sleep(new TimeSpan(0,0,0, rand.Next(0, 5)));

//            return new ProductSearchResult(new Uri(string.Empty), rand.Next());
//        }
//    }
//}
