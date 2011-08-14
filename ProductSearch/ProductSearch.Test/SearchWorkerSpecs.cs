using System;
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
        public void When_a_search_finishes_successfully_it_should_return_success_results()
        {
            // Arrange
            var mockSearchManager = MockRepository.GenerateMock<ISearchManager>();
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository>();
            var searchWorker = new SearchWorker(mockSearchManager.ProcessSearchResults, mockRepo);
            var searchResult = new ProductSearchResult(false, true, string.Empty, 5);

            mockRepo.Stub(x => x.Search("product")).Return(searchResult);

            // Act
            searchWorker.Search("product");

            // Assert
            mockRepo.AssertWasCalled(x => x.Search("product"));
            mockSearchManager.AssertWasCalled(x => x.ProcessSearchResults(searchResult));
        }

        [TestMethod]
        public void When_a_search_fails_it_should_return_failure_results()
        {

        }

        [TestMethod]
        public void When_a_search_is_cancelled_it_should_return_failure_results()
        {

        }
    }
}
