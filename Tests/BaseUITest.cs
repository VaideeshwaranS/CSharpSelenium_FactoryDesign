using DriverManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pages;

namespace Tests
{
    [TestClass]
    public class BaseUITest
    {
        protected DriverFactory instance;
        protected SauceDemoApplication app;

        [TestInitialize]
        public void TestInit()
        {
            instance = new DriverFactory();
            instance.driverService = new DriverService("chrome");
            app = new SauceDemoApplication(instance);
        }

        [TestCleanup]
        public void TestClean()
        {
            app.CloseApp();
        }
    }
}