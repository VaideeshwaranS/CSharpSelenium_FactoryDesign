using DriverManager;
using Elements;
using Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomFrameworkPOC.Pages
{
    public class Dashboard : Page
    {
        public Dashboard(DriverFactory instance) : base(instance)
        {
        }
        public TextField MenuList(string item) => Element.CreateElementByXpath<TextField>($"//span[@title='{item}']/ancestor::li");
        public Hyperlink MenuItem(string item) => Element.CreateElementByXpath<Hyperlink>($"//span[@title='{item}']/parent::a");
        public Hyperlink SubMenu(string item) => Element.CreateElementByXpath<Hyperlink>($"//a[@title='{item}']/parent::li");
        public InputField search => Element.CreateElementByID<InputField>("gridSearchInput");
        public Hyperlink row => Element.CreateElementByXpath<Hyperlink>("//tbody//tr[@role='row']");
        public InputField dateinput => Element.CreateElementByXpath<InputField>("//kendo-datepicker//input");
        public Button save => Element.CreateElementByID<Button>("saveButton");
        public TextField ErrorMsg => Element.CreateElementByID<TextField>("userBusinessAccountDisabledSpan");
        
       public void GotoMenu(string menu)
        {
            var mainmenu = menu.Split(">")[0].Trim();
            var submenu = menu.Split(">")[1].Trim();
            WaitForSpinner(false);
            MenuItem(mainmenu).MoveToElement();
            MenuItem(mainmenu).WaitAndClick();
            if(MenuList(mainmenu).GetValueofAttribute("class").Contains("open")) SubMenu(submenu).WaitAndClick();
            WaitForSpinner(false);
        }

        public string AccountDisabledError()
        {
            ErrorMsg.MoveToElement();
            return ErrorMsg.GetText();
        }

        public void SearchAndSelectRow(string searchtxt)
        {
            search.SendKeysWithClear(searchtxt);
            row.Click();
            WaitForSpinner(false);
        }

        public void ClickSave()
        {
            save.MoveToElement();
            save.WaitAndClick();
            WaitForSpinner(false);
        }
    }
}
