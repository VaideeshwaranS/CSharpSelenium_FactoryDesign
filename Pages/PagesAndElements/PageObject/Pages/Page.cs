using AventStack.ExtentReports;
using PageObject.Elements;
using CoreServices.ReportService;
using OpenQA.Selenium;
using CoreServices;
using OpenQA.Selenium.DevTools.V104.Performance;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CoreServices.Performance;
using PageObject.Pages;

namespace PageObject.Pages
{
    public class Page<M> where M : BaseElement, new()
    {
        IWebDriver driver;
        public IReportService report;
        string URL = "https://repairstack-uat.3m.com/";
        public Page()
        {
            driver = ServiceRegister.Browser.GetWebDriver();
            report = ServiceRegister.ReportService;
        }
        protected M page => new M();
        
        
        public void launchApp()
        {
            report.LogReport(Status.Info, $"Launching the URL{URL}");
            driver.Navigate().GoToUrl(URL);
        }

        public async Task init_Performance()
        {
            await ServiceRegister.Browser.CreateDevToolsSessionAsync();
        }

        public void ClearTiming() => ServiceRegister.Browser.ClearResourceTimings();
        public void WritePerformanceMetrics(string testName)
        {
            PerformanceMetrics perf = ServiceRegister.Performance;
            Console.WriteLine(testName+"\nTotal Time for Navigation : " + perf.TotalTimeforNavigation + "\n" +
                 "Total Script Duration :" + perf.TotalScriptDuration + "\n" +
                  "DOM Loaded Time :" + perf.DomLoaded + "\n" +
                   "First Meaningful Paint Time: " + perf.FirstMeaningfulPaintDuration);
        }

        public void GetPerformanceTiming(string testName)
        {
            PerformanceMetrics perf = ServiceRegister.PerformanceTiming;
            report.LogReport(Status.Info, string.Format("<h1>Test:  {0} <h1><br>" +
                                "DOM Loading time is <mark>{1} ms</mark></br>" +
                                "Total Response Time is <mark>{2} ms</mark></br>" +
                                "<b>Total Time Taken is <mark>{3} ms</mark></b>", testName, perf.DomLoaded,perf.TotalResponseTime,perf.TotalTimeTaken ));
            DBHelper db = new DBHelper();
            db.WriteDatatoTable(testName, perf);
            report.LogReport(Status.Info, db.GetMetricsTableForLast5Date(testName));
        }

        public void WaitForLoadingIcon()
        {
            report.LogReport(Status.Info, $"Waiting for Load icon to complete");
            page.LoadingIcon.isDisplayed(false);
        }

        #region Navigations
        public EquipmentPage NavigateToEquipment()
        {
            report.LogReport(Status.Info, $"Navigating to Equipments Page");
            page.Equipment.Click();
            
            WaitForLoadingIcon();
            return new EquipmentPage();
        }

        public FacilitiesPage NavigateToFacilities()
        {
            report.LogReport(Status.Info, $"Navigating to Facilities Page");
            page.Facilities.Click();
            
            WaitForLoadingIcon();
            return new FacilitiesPage();
        }

        #endregion
    }
}
