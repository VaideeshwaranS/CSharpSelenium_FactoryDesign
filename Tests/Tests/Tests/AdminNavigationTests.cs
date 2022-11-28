using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using PageObject.Elements;
using CoreServices;
using PagesAndElements.PageObject.Pages;
using PagesAndElements.PageObject.Pages.Administration;

namespace Tests
{
    [TestClass]
    public class AdminNavigationTest : BaseUITest
    {
              

        [ClassInitialize]
        public static void initClass(TestContext testContext)
        {
            ServiceRegister.ReportService.StartNewTest(testContext.FullyQualifiedTestClassName);
        }
        [TestMethod]
        public void LoginAsAdmin_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();

            app.ClearTiming();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            app.GetPerformanceTiming(TestContext.TestName);

        }

        [TestMethod]
        public void Users_GridLoad_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();

            app.ClearTiming();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            usersPage.WaitForLoadingIcon();
            app.GetPerformanceTiming(TestContext.TestName);

        }

        [TestMethod]
        public void EquipmentPageLoad_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));

            app.ClearTiming();
            var equipment = app.navigate.NavigateToEquipment();
            Assert.IsTrue(equipment.TabHeaderTextPresent("Stock Locations"));
            app.GetPerformanceTiming(TestContext.TestName);
        }

        [TestMethod]
        public void EquipmentPage_StockLocations_GridLoad_Test()
        {
            LoginPage app = new LoginPage();    
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));

            app.ClearTiming();
            var equipment = app.navigate.NavigateToEquipment();
            Assert.IsTrue(equipment.TabHeaderTextPresent("Stock Locations"));
            Assert.IsTrue(equipment.GridTableLoaded());
            app.GetPerformanceTiming(TestContext.TestName);
        }

        [TestMethod]
        public void EquipmentPage_Devices_GridLoad_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            var equipment = app.navigate.NavigateToEquipment();
            Assert.IsTrue(equipment.TabHeaderTextPresent("Stock Locations"));
            app.ClearTiming();
            equipment.ClickDevicesTab();
            Assert.IsTrue(equipment.TabHeaderTextPresent("Devices"));
            Assert.IsTrue(equipment.GridTableLoaded());
            app.GetPerformanceTiming(TestContext.TestName);
        }

        [TestMethod]
        public void FacilitiesPageLoad_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));

            app.ClearTiming();
            var facilities = app.navigate.NavigateToFacilities();
            Assert.IsTrue(facilities.GetPageTitle().Contains("Facilities"));
            app.GetPerformanceTiming(TestContext.TestName);

        }

        [TestMethod]
        public void Facilities_MSO_Load_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));

            app.ClearTiming();
            var facilities = app.navigate.NavigateToFacilities();
            Assert.IsTrue(facilities.GetPageTitle().Contains("Facilities"));
            Assert.IsTrue(facilities.TabHeaderTextPresent("MSO"));
            Assert.IsTrue(facilities.GridTableLoaded());
            app.GetPerformanceTiming(TestContext.TestName);

        }

        [TestMethod]
        public void Facilities_SSO_Load_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            var facilities = app.navigate.NavigateToFacilities();
            Assert.IsTrue(facilities.GetPageTitle().Contains("Facilities"));

            app.ClearTiming();
            facilities.ClickSSOTab();
            Assert.IsTrue(facilities.TabHeaderTextPresent("SSO"));
            Assert.IsTrue(facilities.GridTableLoaded());
            app.GetPerformanceTiming(TestContext.TestName);

        }

        [TestMethod]
        public void ProductsGrid_loading_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            usersPage.WaitForLoadingIcon();
            NavigationPage navigate = new NavigationPage();
            navigate.OpenAllShopsDropdown();
            navigate.WaitForProgressLoadingIcon();
            Assert.IsTrue(navigate.VerifyOptionDisplayed("All Shops View",120),"All Shops View not displayed after 120 secs");
            navigate.SelectShop(BodyShopName);
            navigate.WaitForLoadingIcon();

            navigate.ClearTiming();
            var products = app.navigate.NavigateToProducts();
            Assert.IsTrue(products.TabHeaderTextPresent("Stock"));
            products.WaitForLoadingIcon();
            navigate.GetPerformanceTiming(TestContext.TestName);
        }

        [TestMethod]
        public void StockLocationsGrid_loading_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            usersPage.WaitForLoadingIcon();
            NavigationPage navigate = new NavigationPage();
            navigate.OpenAllShopsDropdown();
            navigate.WaitForProgressLoadingIcon();
            Assert.IsTrue(navigate.VerifyOptionDisplayed("All Shops View",120), "All Shops View not displayed after 120 secs");
            navigate.SelectShop(BodyShopName);
            navigate.WaitForLoadingIcon();

            navigate.ClearTiming();
            var stockLoc = app.navigate.NavigateToStockLocations();
            stockLoc.WaitForLoadingIcon();
            navigate.GetPerformanceTiming(TestContext.TestName);
        }
    }
}
