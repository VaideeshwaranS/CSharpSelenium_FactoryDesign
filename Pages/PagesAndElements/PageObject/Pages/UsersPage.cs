using AventStack.ExtentReports;
using PageObject.Elements;
using PageObject.Pages;
using PageObject.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace PageObject.Pages
{
    public class UsersPage : Page<Users>
    {
        public string GetPageTitle()
        {
            report.LogReport(Status.Info, $"Get Users Page Title");
            return page.PageTitle.GetText(60);
        }

        public void ClickAddUsers()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} invoked.");
            page.ActionsBar("Add User").Click();
        }
        public void AddNewUser(AddUserEntity adduser)
        {
            page.UserModal.isDisplayed();
            SelectRole(adduser.RoleType);
            SelectOrganization(adduser.Organization);
            enterFirstName(adduser.FirstName);
            enterLastName(adduser.LastName);
            enterEmail(adduser.Email);
            enterUserName(adduser.UserName);
            ClickContinueWithUserRole();
            ChooseUserRole(adduser.RoleCard);
            ClickContinueWithDefaultPermission();
            ClickConfirmAndAddUser();
        }

        public void usersGridKendo()
        {
            page.UsersGrid.SelectRowFromGrid();
        }
        public void enterSearchText(string text)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {text} is invoked.");
            page.SearchBox.SendKeysWithClear(text);
        }
        #region Add user modal
        private void SelectRole(string role)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {role} is invoked.");
            page.Role(role).SelectOption();
        }

        private void SelectOrganization(string text)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {text} is invoked.");
            page.OrgDropdown.SelectValuesByInput(text);
        }

        private void enterFirstName(string text)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {text} is invoked.");
            page.FirstName.SendKeysToInput(text);
        }
        private void enterLastName(string text)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {text} is invoked.");
            page.LastName.SendKeysToInput(text);
        }
        private void enterEmail(string text)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {text} is invoked.");
            page.EmailAddress.SendKeysToInput(text);
        }
        private void enterUserName(string text)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {text} is invoked.");
            page.UserName.SendKeysToInput(text);
        }

        private void ClickContinueWithUserRole()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} is invoked.");
            page.ContinueWithUserRole.Click();
        }
        private void ChooseUserRole(string text)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {text} is invoked.");
            page.UserRoleMatCard(text).Click();
        }
        private void ClickContinueWithDefaultPermission()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} is invoked.");
            page.ContinueWithDefaultPermission.Click();
        }

        private void ClickConfirmAndAddUser()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} is invoked.");
            page.ConfirmAndAddUser.Click(120);
        }
        #endregion
    }
}
