using AventStack.ExtentReports;
using PageObject.Pages;
using PagesAndElements.PageObject.Elements.Administration;
using System;
using System.Reflection;

namespace PagesAndElements.PageObject.Pages.Administration
{
    public class StockLocationPage : Page<StockLocation>
    {
        public bool TabHeaderTextPresent(string header)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} invoked. Checking {header}");
            return page.InnerTab(header).isDisplayed();
        }

 
    }
}
