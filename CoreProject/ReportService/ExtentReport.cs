using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace CoreServices.ReportService
{
    public interface IReportService
    {
        ExtentReports GetExtentReport();
        void StartReport();
        void CloseReport();
        void StartNewTest(string testName);
        void LogReport(Status logStatus, string message);
        void LogReport(Status logStatus, IMarkup markup);
    }
    public class ExtentReport : IReportService
    {
        private const string reportDir = "Reports\\PerformanceReport.html";
        private ExtentReports _extent;
        private ExtentTest _test;
        public void StartReport()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + reportDir;
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "Automation POC for Performance Test");
            _extent.AddSystemInfo("Environment", "UAT - Test Environment");
            _extent.AddSystemInfo("UserName", "AAD Team");
            htmlReporter.LoadConfig(projectPath + "extent-config.xml");
        }

        public void CloseReport()
        {
            _extent.Flush();
        }

        public ExtentReports GetExtentReport()
        {
            return _extent;
        }

        public void StartNewTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public void LogReport(Status logStatus, string message)
        {
            _test.Log(logStatus, message);
        }

        public void LogReport(Status logStatus, IMarkup message)
        {
            _test.Log(logStatus,message);
        }
    }
}
