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
    public class PlanningNavigationTests : BaseUITest
    {
              

        [ClassInitialize]
        public static void initClass(TestContext testContext)
        {
            ServiceRegister.ReportService.StartNewTest(testContext.FullyQualifiedTestClassName);
        }

        [TestMethod]
        public void PlanningJobsNavigation_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();

            app.ClearTiming();
            var usersPage = app.LoginToApp();
            usersPage.WaitForLoadingIcon();
            NavigationPage navigate = new NavigationPage();
            navigate.SelectShopfromAllShops(BodyShopName);
            Assert.IsTrue(navigate.VerifyShopSelected(BodyShopName), "Selected Body shop name is not shown in the top of the Page");
            navigate.NavigateToPlanningJobs();
        }

        [TestMethod]
        public void PlanningBillableInvoicing_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();

            app.ClearTiming();
            var usersPage = app.LoginToApp();
            usersPage.WaitForLoadingIcon();
            NavigationPage navigate = new NavigationPage();
            navigate.SelectShopfromAllShops(BodyShopName);
            Assert.IsTrue(navigate.VerifyShopSelected(BodyShopName), "Selected Body shop name is not shown in the top of the Page");
            navigate.NavigateToBillableInvoicing();

        }

        [TestMethod]
        public void Planning_InvoiceTemplates_Test()
        {
           
        }

        [TestMethod]
        public void Planning_InvoiceMaterialCatalog_Test()
        {
           
        }

        [TestMethod]
        public void Planning_InvoiceGuides_Test()
        {
           
        }

    }
}
