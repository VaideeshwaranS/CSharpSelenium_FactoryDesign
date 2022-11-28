using AventStack.ExtentReports;
using PageObject.Pages;
using PagesAndElements.PageObject.Elements.Administration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PagesAndElements.PageObject.Pages.Administration
{
    public class EquipmentPage : Page<Equipment>
    {
        public bool TabHeaderTextPresent(string header)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} invoked. Checking {header}");
            return page.InnerTab(header).isDisplayed();
        }

        public bool GridTableLoaded()
        {
            report.LogReport(Status.Info, $"Wait For Grid Tabel to Load");
            return page.KendoLoading.isDisplayed(false);
        }

        public void ClickDevicesTab()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} invoked.");
            page.InnerTab("Devices").Click();
            WaitForLoadingIcon();
        }
    }
}
