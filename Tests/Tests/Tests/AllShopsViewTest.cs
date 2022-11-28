using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using PageObject.Elements;
using CoreServices;
using PageObject.Resources;
using PagesAndElements.PageObject.Pages;
using PagesAndElements.PageObject.Pages.Administration;

namespace Tests
{
    [TestClass]
    public class AllShopsViewTest : BaseUITest
    {
        [ClassInitialize]
        public static void initClass(TestContext testContext)
        {
            ServiceRegister.ReportService.StartNewTest(testContext.FullyQualifiedTestClassName);
        }

        [TestMethod]
        public void AllShops_View_loading_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            usersPage.WaitForLoadingIcon();
            NavigationPage navigate = new NavigationPage();
            
            navigate.ClearTiming();
            navigate.OpenAllShopsDropdown();
            navigate.WaitForProgressLoadingIcon();
            navigate.VerifyOptionDisplayed("All Shops View",120);
            navigate.GetPerformanceTiming(TestContext.TestName);
        }

        [TestMethod]
        public void SelectShops_loading_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            usersPage.WaitForLoadingIcon();
            NavigationPage navigate = new NavigationPage();

            navigate.ClearTiming();
            navigate.OpenAllShopsDropdown();
            navigate.WaitForProgressLoadingIcon();
            Assert.IsTrue(navigate.VerifyOptionDisplayed("All Shops View",120), "All Shops View not displayed after 120 secs");
            navigate.SelectShop(BodyShopName);
            navigate.WaitForLoadingIcon();
            navigate.GetPerformanceTiming(TestContext.TestName);
        }



    }
}
