using AventStack.ExtentReports;
using CoreServices;
using CoreServices.DriverManager;
using CoreServices.ReportService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject;

namespace Tests
{
    [TestClass]
    public class BaseUITest 
    {
        public TestContext TestContext { get; set; }
        private IReportService report;

        [TestInitialize]
        public void TestInit()
        {
           ServiceRegister.tcCounter++;
           report = ServiceRegister.ReportService;
           ServiceRegister.Browser = new DriverService("chrome", TestContext.TestName);
           report.CreateTestMethod(ServiceRegister.tcCounter+" "+TestContext.TestName);
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