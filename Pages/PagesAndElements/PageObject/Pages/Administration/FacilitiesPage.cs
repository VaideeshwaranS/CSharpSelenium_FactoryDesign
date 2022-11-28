using AventStack.ExtentReports;
using PageObject.Pages;
using PagesAndElements.PageObject.Elements.Administration;
using System;
using System.Reflection;

namespace PagesAndElements.PageObject.Pages.Administration
{
    public class FacilitiesPage : Page<Facilities>
    {
        public string GetPageTitle()
        {
            report.LogReport(Status.Info, $"Get Page Title");
            return page.PageTitle.GetText();
        }

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

        public void ClickSSOTab()
        {
            report.LogReport(Status.Info, $"Wait For Grid Tabel to Load");
            page.InnerTab("SSO").Click();
        }
    }
}
