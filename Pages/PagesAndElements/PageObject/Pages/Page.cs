using AventStack.ExtentReports;
using PageObject.Elements;
using CoreServices.ReportService;
using OpenQA.Selenium;
using CoreServices;
using System;
using System.Threading.Tasks;
using CoreServices.Performance;
using System.Reflection;
using PagesAndElements.PageObject.Pages;

namespace PageObject.Pages
{
    public class Page<M> where M : BaseElement, new()
    {
        IWebDriver driver;
        public IReportService report;
        protected string URL = "https://repairstack.3m.com/";
        protected string ENV = "PreProd";
        protected string userName = "testsuperuser";
        protected string password = "Test@1234567";

        public Page()
        {
            driver = ServiceRegister.Browser.GetWebDriver();
            report = ServiceRegister.ReportService;
        }
        protected M page => new M();

        public NavigationPage navigate => new NavigationPage();
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
            DBHelper db = new DBHelper(ENV);
            db.WriteDatatoTable(testName, perf);
            var message = "<b> Performance Metrics for last 5 runs: </b><br>"+db.GetTableMarkupforLast5Runs(testName).GetMarkup();
            report.PerfLogTest(Status.Info, message );
            
        }

        public void WaitForLoadingIcon()
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} to complete");
            page.LoadingIcon.isDisplayed(false);
        }

        public void WaitForProgressLoadingIcon(int maxSecs = 60)
        {
            report.LogReport(Status.Info, $"{MethodBase.GetCurrentMethod().Name} to finish");
            page.MatLoader.isDisplayed(false,maxSecs);
        }

        #region Toast Message
        public string GetToastMessage(int secs = 60)
        {
            return page.ToastMessage.GetText(secs);
        }
        #endregion

        
    }
}
