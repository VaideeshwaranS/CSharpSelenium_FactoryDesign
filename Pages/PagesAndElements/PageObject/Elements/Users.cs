using Elements;
using PageObject.Elements;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Elements
{
    public class Users : BaseElement
    {
        public TextField PageTitle => Element.CreateElementByXpath<TextField>("//h4[contains(@class,'page-title')]");
        public Button ActionsBar(string action) => Element.CreateElementByXpath<Button>($"//div[@class='actions-container']//span[contains(.,'{action}')]/ancestor::button");
        public InputField SearchBox => Element.CreateElementByID<InputField>("search-input");
        public KendoGridTable UsersGrid => Element.CreateElementByXpath<KendoGridTable>("//lib-user-managmenet-grid/Kendo-grid");
        #region Add User Modal
        public TextField UserModal => Element.CreateElementByID<TextField>("userDetailDialog");
        public RadioButton Role(string role) => Element.CreateElementByXpath<RadioButton>($"//*[@id='userDetailDialog']//label[contains(.,'{role}')]/preceding-sibling::input");
        public Dropdown OrgDropdown => Element.CreateElementByXpath<Dropdown>("//ng-select[@id='org']");
        public InputField UsersInputField(string id) => Element.CreateElementByXpath<InputField>($"//soc-text-input[@id='{id}']");
        public Button GetButton(string text) => Element.CreateElementByXpath<Button>($"//button/span[text()='{text}']");
        public InputField FirstName => UsersInputField("firstName");
        public InputField LastName => UsersInputField("lastName");
        public InputField EmailAddress => UsersInputField("email");
        public InputField UserName => UsersInputField("userName");
        public InputField Phone => UsersInputField("phone");
        public InputField Extension => UsersInputField("extension");
        public Dropdown Language => Element.CreateElementByXpath<Dropdown>("//ng-select[@id=language']");
        public Button UserRoleMatCard(string roleCard) => Element.CreateElementByXpath<Button>($"//mat-card//mat-card-title[contains(.,'{roleCard}')]");
        public Button Cancel => GetButton("Cancel");
        public Button ContinueWithUserRole => GetButton("Continue With User Role");
        public Button ContinueWithDefaultPermission => GetButton("Continue With Default Permissions");
        public Button ModifyPermission => GetButton("Modify Permissions");
        public Button RetrunToPrev => GetButton("Return To Previous Step");
        public Button ConfirmAndAddUser => GetButton("Confirm and Add User");
        #endregion
    }
}
