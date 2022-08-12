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
            app.launchApp();
            app._loginpage.LoginToApp();
            app._productsPage.Productname("Sauce Labs Backpack").Click();
            var text = app._productsPage.productdetail.ProductDesc("Sauce Labs Backpack").GetText();
            Console.WriteLine(text);
        }
    }
}
