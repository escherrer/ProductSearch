using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSearch.ViewModel;

namespace ProductSearch.Test
{
    [TestClass]
    public class BestBuyProductSearchIntegration
    {
        [TestMethod]
        public void Test_BestBuy_successful_search()
        {
            /*
             * 
             * Based on the assumption of a product search of "iphone" returning a particular result
             * 
             */

            var vm = new MainWindowViewModel();

            vm.SearchCommand.Execute("iphone");

            Assert.IsTrue(vm.IsSearching);

            Thread.Sleep(5000);

            Assert.IsFalse(vm.IsSearching);

            Assert.AreEqual(29.99m, vm.ProductPrice);
            Assert.AreEqual("http://images.bestbuy.com/BestBuy_US/images/products/9321/9321245_s.gif", vm.ProductImage.ToString());
        }

        [TestMethod]
        public void Test_BestBuy_failed_search()
        {
            /*
             * 
             * Based on the assumption of a product search of "hgjhgj" returning no results
             * 
             */

            var vm = new MainWindowViewModel();

            vm.SearchCommand.Execute("hgjhgj");

            Assert.IsTrue(vm.IsSearching);

            Thread.Sleep(5000);

            Assert.IsFalse(vm.IsSearching);

            Assert.IsNull(vm.ProductPrice);
            Assert.AreEqual("Images/blank_image.jpg", vm.ProductImage.ToString());
        }

        [TestMethod]
        public void Test_BestBuy_search_with_no_image()
        {
            /*
             * 
             * Based on the assumption of a product search of "cable" returning results with no image
             * 
             */

            var vm = new MainWindowViewModel();

            vm.SearchCommand.Execute("cable");

            Assert.IsTrue(vm.IsSearching);

            Thread.Sleep(5000);

            Assert.IsFalse(vm.IsSearching);

            Assert.AreEqual(38.98m, vm.ProductPrice);
            Assert.AreEqual("Images/no_image.jpg", vm.ProductImage.ToString());
        }
    }
}
