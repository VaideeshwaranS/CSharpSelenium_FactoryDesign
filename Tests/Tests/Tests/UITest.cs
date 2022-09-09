using PageObject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class UITest : BaseUITest
    {
       
        [TestMethod]
        public async Task ProductsDetailPage_PerformanceTest()
        {
            LoginPage _login = new LoginPage();
            ProductsPage _product = new ProductsPage();
            
            _login.launchApp("https://www.saucedemo.com/");
            _login.LoginToApp();

            await _product.init_Performance();
            _product.ClickProduct("Sauce Labs Onesie");
            _product.GetProductDesc("Sauce Labs Onesie");
            _product.WritePerformanceMetrics();
            
            Assert.IsTrue(true);
        }
    }
}
