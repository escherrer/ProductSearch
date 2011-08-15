using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Exceptions;
using ProductSearch.Model;
using ProductSearch.Utility;
using Rhino.Mocks;

namespace ProductSearch.Test
{
    [TestClass]
    public class ProductSearchWorkerSpecs
    {
        [TestInitialize]
        public void MyTestInitialize()
        {

        }

        [TestMethod]
        public void When_a_search_is_performed_it_queries_the_repo_and_returns_results_asyncronously()
        {
            var isComplete = false;
            ProductSearchResult results = null;

            // Arrange
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository>();
            var searchResult = new ProductSearchResult(false, false, string.Empty, 5);

            mockRepo.Stub(x => x.Search("product")).Return(searchResult);

            var searchWorker = new ProductSearchWorker(mockRepo, (cb) =>
            {
                Thread.Sleep(500);
                isComplete = true;
                results = cb;
            });

            // Act
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

        [TestMethod]
        public void When_a_search_is_cancelled_it_calls_back_with_a_cancelled_result()
        {
            ProductSearchResult results = null;

            // Arrange
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository>();
            var searchResult = new ProductSearchResult(false, false, string.Empty, 5);

            mockRepo.Stub(x => x.Search("product")).Do((Func<string, ProductSearchResult>) delegate
            {
                Thread.Sleep(2000);
                return searchResult;
            });

            var searchWorker = new ProductSearchWorker(mockRepo, (cb) =>
            {
                results = cb;
            });

            // Act
            searchWorker.BeginSearch("product");
            searchWorker.CancelSearch();

            Thread.Sleep(5000);

            // Assert
            Assert.IsTrue(results.IsCancelled);
        }

        [TestMethod]
        public void A_product_search_worker_can_only_be_fired_off_once()
        {
            // Arrange
            Exception ex = null;
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository>();
            var searchResult = new ProductSearchResult(false, false, string.Empty, 5);

            mockRepo.Stub(x => x.Search("product")).Return(searchResult);

            var searchWorker = new ProductSearchWorker(mockRepo, (cb) => { });

            // Act
            searchWorker.BeginSearch("product");

            try
            {
                searchWorker.BeginSearch("product");
            }
            catch (AlreadySearchingException e)
            {
                ex = e;
            }

            // Assert
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void A_product_search_worker_can_only_be_cancelled_if_there_has_been_a_search()
        {
            // Arrange
            Exception ex = null;
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository>();
            var searchResult = new ProductSearchResult(false, false, string.Empty, 5);

            mockRepo.Stub(x => x.Search("product")).Return(searchResult);

            var searchWorker = new ProductSearchWorker(mockRepo, (cb) => { });

            try
            {
                searchWorker.CancelSearch();
            }
            catch (NoSearchToCancelException e)
            {
                ex = e;
            }

            // Assert
            Assert.IsNotNull(ex);
        }
    }
}
