using AventStack.ExtentReports;
using PageObject.Elements;
using CoreServices.ReportService;
using OpenQA.Selenium;
using CoreServices;
using System;
using System.Threading.Tasks;
using CoreServices.Performance;
using System.Reflection;

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

        public void ClearTiming()
        {
            ServiceRegister.Browser.ClearResourceTimings();
            report.LogReport(Status.Info, "Cleared Performance Timing in browser");
        }
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
            report.LogReport(Status.Info, string.Format("<b>Performance Metrics Collected:</b>  {0} <br>" +
                                "DOM Loading time is <mark>{1}</mark> ms</br>" +
                                "Total Response Time is <mark>{2}</mark> ms</br>" +
                                "<b>Total Time Taken is <mark>{3}</mark> ms</b>", testName, perf.DomLoaded,perf.TotalResponseTime,perf.TotalTimeTaken ));
            DBHelper db = new DBHelper();
            db.WriteDatatoTable(testName, perf);
            var message = "<b> Performance Metrics for last 5 runs: </b><br>"+db.GetTableMarkupforLast5Runs(testName).GetMarkup();
            report.LogReport(Status.Pass, message );
            
        }

        public void WaitForLoadingIcon()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} to complete");
            page.LoadingIcon.isDisplayed(false);
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

        #endregion
    }
}
