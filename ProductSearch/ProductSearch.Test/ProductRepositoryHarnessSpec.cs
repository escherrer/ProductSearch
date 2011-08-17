using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSearch.DataAccess.Repository;
using ProductSearch.Exceptions;
using ProductSearch.Model;
using Rhino.Mocks;

namespace ProductSearch.Test
{
    [TestClass]
    public class ProductRepositoryHarnessSpec
    {
        [TestMethod]
        public void Should_return_error_is_true_if_error_has_occurred()
        {
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository<Product>>();

            mockRepo.Stub(x => x.Search("product")).Do((Func<string, Product>)delegate
            {
                throw new DataAccessException("test", new Exception());
            });

            var harness = new ProductRepositoryHarness(mockRepo);

            var result = harness.Search("product");

            Assert.IsTrue(result.HasError);
        }

        [TestMethod]
        public void Should_return_productSearchResult_with_correct_output()
        {
            var mockRepo = MockRepository.GenerateMock<IProductSearchRepository<Product>>();

            mockRepo.Stub(x => x.Search("product")).Do((Func<string, Product>)delegate
            {
                return new Product(string.Empty, "5");
            });

            var harness = new ProductRepositoryHarness(mockRepo);

            var result = harness.Search("product");

            Assert.AreEqual("5", result.Product.SalePrice);
            Assert.AreEqual(string.Empty, result.Product.imageUrl);
        }
    }
}
