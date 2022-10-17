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

namespace PageObject.Pages
{
    public class Page<M> where M : BaseElement, new()
    {
        IWebDriver driver;
        public IReportService report;
        public Page()
        {
            driver = ServiceRegister.Browser.GetWebDriver();
            report = ServiceRegister.ReportService;
        }
        protected M page => new M();
        
        
        public void launchApp(string url)
        {
            report.LogReport(Status.Info, $"Launching the URL{url}");
            driver.Navigate().GoToUrl(url);
        }

        public async Task init_Performance()
        {
            await ServiceRegister.Browser.CreateDevToolsSessionAsync();
        }
        public void WritePerformanceMetrics(string testName)
        {
            PerformanceMetrics perf = ServiceRegister.Performance;
            Console.WriteLine(testName+"\nTotal Time for Navigation : " + perf.TotalTimeforNavigation + "\n" +
                 "Total Script Duration :" + perf.TotalScriptDuration + "\n" +
                  "DOM Loaded Time :" + perf.DomLoaded + "\n" +
                   "First Meaningful Paint Time: " + perf.FirstMeaningfulPaintDuration);
        }
    }
}
