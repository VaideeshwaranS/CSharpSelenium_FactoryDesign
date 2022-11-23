using PageObject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using PageObject.Elements;
using CoreServices;

namespace Tests
{
    [TestClass]
    public class NavigationTest : BaseUITest
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
            var equipment = app.NavigateToEquipment();
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
            var equipment = app.NavigateToEquipment();
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
            var equipment = app.NavigateToEquipment();
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
            var facilities = app.NavigateToFacilities();
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
            var facilities = app.NavigateToFacilities();
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
            var facilities = app.NavigateToFacilities();
            Assert.IsTrue(facilities.GetPageTitle().Contains("Facilities"));

            app.ClearTiming();
            facilities.ClickSSOTab();
            Assert.IsTrue(facilities.TabHeaderTextPresent("SSO"));
            Assert.IsTrue(facilities.GridTableLoaded());
            app.GetPerformanceTiming(TestContext.TestName);

        }
    }
}
