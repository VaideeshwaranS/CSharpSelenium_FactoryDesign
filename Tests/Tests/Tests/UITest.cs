using PageObject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class NavigationTest : BaseUITest
    {

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
    }
}
