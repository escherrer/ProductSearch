using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Model;
using ProductSearch.Utility;
using Rhino.Mocks;

namespace ProductSearch.Test
{
    [TestClass]
    public class SearchWorkerSpecs
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {

        }

        [TestMethod]
        public void When_a_search_is_performed_it_queries_the_repo_and_returns_results()
        {
            var isComplete = false;
            ProductSearchResult results = null;

            // Arrange
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository>();
            var searchResult = new ProductSearchResult(false, string.Empty, 5);

            mockRepo.Stub(x => x.Search("product")).Return(searchResult);

            // Act
            var searchWorker = new ProductSearchWorker(mockRepo, (cb) =>
            {
                Thread.Sleep(500);
                isComplete = true;
                results = cb; 
            });
            searchWorker.BeginSearch("product");

            Assert.IsNull(results);
            while (!isComplete)
            {
                Thread.Sleep(1000);
            }

            // Assert
            mockRepo.AssertWasCalled(x => x.Search("product"));
            Assert.AreSame(searchResult, results);
        }
    }
}
