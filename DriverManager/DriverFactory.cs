using OpenQA.Selenium;

namespace DriverManager
{

    public abstract class DriverFactory
    {
     
        public abstract void CreateDriver();

        public abstract void CloseDriver();

        public abstract WebDriver getDriver();
    }
}
