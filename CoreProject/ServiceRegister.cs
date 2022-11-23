using CoreServices.DriverManager;
using CoreServices.Performance;
using CoreServices.ReportService;
using Elements;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Text;

namespace CoreServices
{
    public static class ServiceRegister
    {
        public enum BrowserTypes
        {
            Chrome,
            Firefox
        }
        private static WebDriverWait browserWait;
        private static IDriverService browser;
        private static IReportService reportService;

        public static IDriverService Browser
        {
            get
            {
                if (browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return browser;
            }
            set
            {
                browser = value;
                BrowserWait = new WebDriverWait(browser.GetWebDriver(), TimeSpan.FromSeconds(60));
            }
        }
        public static WebDriverWait BrowserWait
        {
            get
            {
                if (browserWait == null || browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return browserWait;
            }
            private set
            {
                browserWait = value;
            }
        }

        public static IReportService ReportService
        {
            get
            {
                if (reportService == null)
                {
                    throw new NullReferenceException("Extent Report is not initialized");
                }
                return reportService;
            }
            set
            {
                reportService = value;
            }
        }

        public static DataTable perfConsolidated = new DataTable();
        public static int tcCounter = 0;
        public static PerformanceMetrics Performance => browser.GetPerformanceMetricsAsync().Result;

        public static PerformanceMetrics PerformanceTiming => browser.GetPerformanceTiming();
        public static ElementService Element => new ElementService(browser.GetWebDriver());
    }
}
