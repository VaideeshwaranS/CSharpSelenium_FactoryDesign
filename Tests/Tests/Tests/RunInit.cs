using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using CoreServices;
using CoreServices.ReportService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Text;

namespace Tests
{

    [TestClass]
    public static class RunInit
    {
        
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            ServiceRegister.ReportService = new ExtentReport();
            ServiceRegister.ReportService.StartReport();
           
            
        }

        [AssemblyCleanup]
        public static void CleanUpTests()
        {
            ServiceRegister.ReportService.CloseReport();
        }
    }

}