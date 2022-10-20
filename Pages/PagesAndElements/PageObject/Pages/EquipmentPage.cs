using AventStack.ExtentReports;
using PageObject.Elements;
using PageObject.Pages;

using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Pages
{
    public class EquipmentPage : Page<Equipment>
    {
        public bool TabHeaderTextPresent(string header)
        {
            report.LogReport(Status.Info, $"Get Page Title");
            return page.Tab(header).isDisplayed();
        }
    }
}
