using Elements;
using PageObject.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagesAndElements.PageObject.Elements
{
    public class Navigation:BaseElement
    {
        public Button HamburgerMenu => Element.CreateElementByXpath<Button>("//div[@class='hamburger']");

        public string Menu(string item) => $"//mat-nested-tree-node/li/div[@title='{item}']";
        public Button MenuArrow(string item) => Element.CreateElementByXpath<Button>($"{Menu(item)}/i");
        public  TextField MenuItem(string item) => Element.CreateElementByXpath<TextField>($"{Menu(item)}/span");
        public TextField SubMenu(string item,string subItem) => Element.CreateElementByXpath<TextField>($"{Menu(item)}/following-sibling::ul//div[@title='{subItem}']/span");
        public Hyperlink Equipment => Element.CreateElementByID<Hyperlink>("nav-link-Admin.Equipment");
        public Hyperlink Facilities => Element.CreateElementByID<Hyperlink>("nav-link-Admin.Facilities");
        public Hyperlink Products => Element.CreateElementByID<Hyperlink>("nav-link-Admin.Product");
        public Hyperlink StockLocations => Element.CreateElementByID<Hyperlink>("nav-link-Admin.StockLocations");
        public Dropdown AllShopsDropdown => Element.CreateElementByXpath<Dropdown>("//shop-dropdown");
        public string AllShopsOverview => "//*[contains(@class,'shop-dropdown-overlay')]";
        public TextField ShopsOption(string value) => Element.CreateElementByXpath<TextField>($"{AllShopsOverview}//div[contains(@class,'mat-option')][normalize-space()='{value}']");
    
        public void ClickMenu(string breadcrumb)
        {
           string menuItem = breadcrumb.Split(">")[0];
           string subMenu = breadcrumb.Split(">")[1];

            HamburgerMenu.Click();

            if (MenuArrow(menuItem).GetAttribute("class").Equals("icon-chevron_down"))
            {
                MenuArrow(menuItem).Click();
                SubMenu(menuItem,subMenu).Click();
            }
            
        }
    
    }
}
