using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace CustomFrameworkPOC.ReportService
{
    public interface IReportService
    {
        ExtentReports GetExtentReport();
        void StartReport();
        void CloseReport();
        void StartNewTest(string testName);
        void LogReport(Status logStatus, string message);
    }
    public class ExtentReport : IReportService
    {
        private ExtentReports _extent;
        private ExtentTest _test;
        public void StartReport()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            Console.WriteLine(projectPath.ToString());
            var reportPath = projectPath + "Reports\\Index.html";
            Console.WriteLine(reportPath);
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "Automation POC for C# Framework");
            _extent.AddSystemInfo("Environment", "Test Environment");
            _extent.AddSystemInfo("UserName", "Vaideeshwaran");
            //htmlReporter.LoadConfig(projectPath + "report-config.xml");
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

    }
}
