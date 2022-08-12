using DriverManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pages;

namespace Tests
{
    [TestClass]
    public class BaseUITest 
    {
        public DriverInstance instance;
        protected LoginPage login;

        [TestInitialize]
        public void TestInit()
        {
            instance = new DriverInstance("chrome");
            login = new LoginPage(instance);
        }

        [TestCleanup]
        public void TestClean()
        {
            instance.CloseDriver();
        }
    }
}