using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;
using ProductSearch.Utility;
using Rhino.Mocks;

namespace ProductSearch.Test
{
    [TestClass]
    public class ProductSearchManagerSpecs
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            
        }

        [TestMethod]
        public void Only_the_most_recent_search_returns_results()
        {
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository>();
            string lastReturnedProduct = null;
            var callbacks = 0;

            mockRepo.Stub(x => x.Search("product1")).Do((Func<string, ProductSearchResult>) delegate
            {
                Thread.Sleep(1000);
                return new ProductSearchResult(false, false, "product1Url", 5m);
            });

            mockRepo.Stub(x => x.Search("product2")).Do((Func<string, ProductSearchResult>)delegate
            {
                Thread.Sleep(1000);
                return new ProductSearchResult(false, false, "product2Url", 5m);
            });

            mockRepo.Stub(x => x.Search("product3")).Do((Func<string, ProductSearchResult>)delegate
            {
                Thread.Sleep(500);
                return new ProductSearchResult(false, false, "product3Url", 5m);
            });

            var productSearchManager = new ProductSearchManager();
            productSearchManager.ResultsRecieved += (results) =>
                                                        {
                                                            callbacks++;
                                                            lastReturnedProduct = results.ImageUrl;
                                                        };

            productSearchManager.DoSearch("product1", mockRepo);
            productSearchManager.DoSearch("product2", mockRepo);
            productSearchManager.DoSearch("product3", mockRepo);

            Thread.Sleep(5000);

            Assert.AreEqual("product3Url", lastReturnedProduct);
            Assert.AreEqual(1, callbacks);
        }
    }
}
