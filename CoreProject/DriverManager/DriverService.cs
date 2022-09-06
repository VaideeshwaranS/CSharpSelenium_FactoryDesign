using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace CustomFrameworkPOC.DriverManager
{
    public interface IDriverService
    {
        IWebDriver GetWebDriver();
        void CloseDriver();
        void NavigateBack();
        void Refresh();
    }
    public class DriverService : IDriverService
    {
        private IWebDriver driver;
       
        public DriverService(string browser)
        {
           driver = browser switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new Exception("Invalid Browser name")
            };
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }
        public IWebDriver GetWebDriver()
        {
            return driver;
        }
               
        public  void CloseDriver() => driver.Close();

        public  void NavigateBack() => driver.Navigate().Back();

        public  void Refresh() => driver.Navigate().Refresh();

    }
}
