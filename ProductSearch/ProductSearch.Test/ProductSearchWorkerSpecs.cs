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
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository<Product>>();
            var product = new Product(string.Empty, string.Empty);

            mockRepo.Stub(x => x.Search("product")).Return(product);

            // Act
            new ProductSearchWorker(mockRepo, (cb, worker) =>
                {
                    Thread.Sleep(500);
                    isComplete = true;
                    results = cb;
                }, "product");

            // Confirm no return yet
            Assert.IsNull(results);

            while (!isComplete)
            {
                Thread.Sleep(1000);
            }

            // Assert
            mockRepo.AssertWasCalled(x => x.Search("product"));
            Assert.AreSame(product, results.Product);
            Assert.IsFalse(results.IsCancelled);
        }

        [TestMethod]
        public void When_a_search_is_cancelled_it_calls_back_with_a_cancelled_result()
        {
            ProductSearchResult results = null;

            // Arrange
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository<Product>>();
            var searchResult = new Product(string.Empty, string.Empty);

            mockRepo.Stub(x => x.Search("product")).Do((Func<string, Product>) delegate
            {
                Thread.Sleep(2000);
                return searchResult;
            });

            // Act
            var searchWorker = new ProductSearchWorker(mockRepo, (cb, worker) =>
            {
                results = cb;
            }, "product");
            searchWorker.CancelSearch();

            Thread.Sleep(5000);

            // Assert
            Assert.IsTrue(results.IsCancelled);
        }

        [TestMethod]
        public void When_a_search_is_performed_and_the_repository_fails_results_indicate_an_error_occurred()
        {
            var isComplete = false;
            ProductSearchResult results = null;

            // Arrange
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository<Product>>();

            mockRepo.Stub(x => x.Search("product")).Do((Func<string, Product>)delegate
            {
                throw new Exception();
            });

            // Act
            new ProductSearchWorker(mockRepo, (cb, worker) =>
            {
                isComplete = true;
                results = cb;
            }, "product");

            while (!isComplete)
            {
                Thread.Sleep(1000);
            }

            // Assert
            mockRepo.AssertWasCalled(x => x.Search("product"));
            Assert.IsTrue(results.HasError);
        }
    }
}
