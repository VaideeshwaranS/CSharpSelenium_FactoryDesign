using CustomFrameworkPOC.PerformanceMetrics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.DevTools.V104.Performance;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UITest : BaseUITest
    {
        [TestMethod]
        public void FirstTest()
        {
            app._loginpage.LoginToApp();
            PerformanceMetricsMap metrics = instance.GetPerformanceMetrics();
            instance.GetNetworkLog();
            app._productsPage.Productname("Sauce Labs Backpack").Click();
            var text = app._productsPage.productdetail.ProductDesc("Sauce Labs Backpack").GetText();
            Console.WriteLine(text);

        }

        [TestMethod]
        public void SecondTest()
        {
            app._loginpage.LoginToApp();
            Assert.IsTrue(app._loginpage.ActiveGridTitle("Overview").isDisplayed());
            app._dashboard.GotoMenu("Administration > User Management ");
            Assert.IsTrue(app._dashboard.ActiveGridTitle("Users").isDisplayed());
            app._dashboard.SearchAndSelectRow("ajs");
            app._dashboard.dateinput.enterDate("07/07/2022");
            app._dashboard.ClickSave();
            Assert.IsTrue(app._dashboard.AccountDisabledError().Contains("This account is disabled"), "Failed");
        }
    }
}
