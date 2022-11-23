using PageObject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using PageObject.Elements;
using CoreServices;
using PageObject.Resources;

namespace Tests
{
    [TestClass]
    public class UserTest : BaseUITest
    {
        [ClassInitialize]
        public static void initClass(TestContext testContext)
        {
            ServiceRegister.ReportService.StartNewTest(testContext.FullyQualifiedTestClassName);
        }

        [TestMethod]
        public void CreateUser_Load_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            usersPage.WaitForLoadingIcon();
            var userDtails = new AddUserEntity()
            {
                RoleType = "Single Repair Facility",
                Organization = "CongruentSSO",
                FirstName = "Auto_First_12345",
                LastName = "Auto_Last_12345",
                Email = "email@test.com",
                UserName = "Auto_User_12345",
                RoleCard = "Technician"
            };

            app.ClearTiming();
            usersPage.ClickAddUsers();
            usersPage.AddNewUser(userDtails);
            Assert.IsTrue(usersPage.GetToastMessage(120).Equals(userDtails.FirstName + " " + userDtails.LastName + " " + "was added"));
            app.GetPerformanceTiming(TestContext.TestName);
        }

        [TestMethod]
        public void SearchUser_Load_Test()
        {
            LoginPage app = new LoginPage();
            app.launchApp();
            var usersPage = app.LoginToApp();
            Assert.IsTrue(usersPage.GetPageTitle().Contains("Users"));
            usersPage.WaitForLoadingIcon();
          
            usersPage.enterSearchText("Auto_User_12345");
            usersPage.WaitForLoadingIcon();
            usersPage.usersGridKendo();
        }

    }
}
