using AventStack.ExtentReports;
using Elements;
using PageObject.Elements;
using PageObject.Pages;
using PagesAndElements.PageObject.Elements;
using PagesAndElements.PageObject.Pages.Administration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PagesAndElements.PageObject.Pages
{
    public class NavigationPage : Page<Navigation>
    {
        public bool VerifyOptionDisplayed(string value, int maxSec=60)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} for {value} is invoked");
            return page.ShopsOption(value).isDisplayed(true,maxSec);
        }

        public void SelectShop(string value)
        {
            enterShopsValue(value);
            if (VerifyOptionDisplayed(value))
                SelectDisplayedOption(value);
            else
                throw new Exception("Entered Shop not lised in Dropdown");
        }

        public void SelectShopfromAllShops(string value)
        {
            OpenAllShopsDropdown();
            WaitForProgressLoadingIcon();
            if (VerifyOptionDisplayed("All Shops View", 120))
            {
                enterShopsValue(value);
                if (VerifyOptionDisplayed(value))
                    SelectDisplayedOption(value);
                else
                    throw new Exception("Entered Shop not lised in Dropdown");
            }

        }
        public bool VerifyShopSelected(string text)
        {
            return page.AllShopsDropdown.GetValuesFromDropdownInput().Equals(text);

        }
        private void SelectDisplayedOption(string value)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {value} is invoked");
            page.ShopsOption(value).Click();
        }
        private void enterShopsValue(string value)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} with {value} is invoked");
            page.AllShopsDropdown.SendValues(value);
        }

        public void OpenAllShopsDropdown()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} is invoked");
            page.AllShopsDropdown.Click();
        }

        #region Navigations
        public EquipmentPage NavigateToEquipment()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} Page");
            page.Equipment.Click();

            WaitForLoadingIcon();
            return new EquipmentPage();
        }

        public FacilitiesPage NavigateToFacilities()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} Page");
            page.Facilities.Click();

            WaitForLoadingIcon();
            return new FacilitiesPage();
        }

        public ProductsPage NavigateToProducts()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} Page");
            page.Products.Click();

            WaitForLoadingIcon();
            return new ProductsPage();
        }

        public StockLocationPage NavigateToStockLocations()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} Page");
            page.StockLocations.Click();

            WaitForLoadingIcon();
            return new StockLocationPage();
        }

        public void NavigateToPlanningJobs()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} Page");
            page.ClickMenu("Planning>Jobs");
            WaitForLoadingIcon();

        }
        public void NavigateToBillableInvoicing()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} Page");
            page.ClickMenu("Planning>Billables Invoicing");
            WaitForLoadingIcon();
        }
        #endregion
    }
}
