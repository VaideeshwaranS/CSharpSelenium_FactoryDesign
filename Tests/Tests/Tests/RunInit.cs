using CoreServices;
using CoreServices.ReportService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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