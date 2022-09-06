using AventStack.ExtentReports;
using CustomFrameworkPOC;
using CustomFrameworkPOC.DriverManager;
using CustomFrameworkPOC.ReportService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BaseUITest 
    {
        public ExtentTest _test;
        public ExtentReports _extent;
        public TestContext TestContext { get; set; }
        private IReportService report;

        [TestInitialize]
        public void TestInit()
        {
           report = ServiceRegister.ReportService;
           ServiceRegister.Browser = new DriverService("chrome");
           report.StartNewTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TestClean()
        {
            ServiceRegister.Browser.CloseDriver();
            Status logstatus = TestContext.CurrentTestOutcome switch
            {
                UnitTestOutcome.Failed =>  Status.Fail,
                UnitTestOutcome.Inconclusive =>  Status.Fatal,
                UnitTestOutcome.Passed =>  Status.Pass,
                UnitTestOutcome.InProgress => Status.Skip,
                UnitTestOutcome.Error =>  Status.Error,
                UnitTestOutcome.Timeout => Status.Skip,
                UnitTestOutcome.Aborted =>  Status.Debug,
                UnitTestOutcome.Unknown =>  Status.Debug,
                UnitTestOutcome.NotRunnable => Status.Skip,
                _ => Status.Warning,
            };
            report.LogReport(logstatus, " Status:" + logstatus);
        }
    }
}