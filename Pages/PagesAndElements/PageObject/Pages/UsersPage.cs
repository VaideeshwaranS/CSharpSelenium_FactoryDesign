using AventStack.ExtentReports;
using PageObject.Elements;
using PageObject.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Pages
{
    public class UsersPage : Page<Users>
    {
        public string GetPageTitle()
        {
            report.LogReport(Status.Info, $"Get Users Page Title");
            return page.PageTitle.GetText();
        }
    }
}
