using AventStack.ExtentReports;
using CustomFrameworkPOC.PageObject.Elements;
using CustomFrameworkPOC.ReportService;
using OpenQA.Selenium;

namespace CustomFrameworkPOC.PageObject.Pages
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
    }

}
