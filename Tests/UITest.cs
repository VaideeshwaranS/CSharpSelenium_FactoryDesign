using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UITest : BaseUITest
    {
        [TestMethod]
        public void FirstTest()
        {
            instance.LaunchApp();
            login.PerformanceofLoginToSauceDemo();
        }
    }
}
