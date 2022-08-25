using CustomFrameworkPOC.PageObject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class UITest : BaseUITest
    {
        [TestMethod]
        public void FirstTest()
        {
            LoginPage _login = new LoginPage();
            ProductsPage _product = new ProductsPage();
            _login.launchApp("https://www.saucedemo.com/");
            _login.LoginToApp();
            Assert.Fail();
        }

        [TestMethod]
        public void SecondTest()
        {
            LoginPage _login = new LoginPage();
            ProductsPage _product = new ProductsPage();
            _login.launchApp("https://www.saucedemo.com/");
            _login.LoginToApp();
            _product.ClickProduct("Sauce Labs Onesie");
            Console.WriteLine(_product.GetProductDesc("Sauce Labs Onesie"));
            Assert.IsTrue(true);
        }
    }
}
