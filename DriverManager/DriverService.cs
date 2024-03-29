﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace DriverManager
{
    public interface IDriverService
    {
        IWebDriver GetWebDriver();
    }
    public class DriverService : IDriverService
    {
        private IWebDriver driver;
        private string browser;
        public DriverService(string browser)
        {
            this.browser = browser;
        }
        public IWebDriver GetWebDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.SetLoggingPreference("performance", LogLevel.All);

            driver = browser switch
            {
                "chrome" => new ChromeDriver(chromeOptions),
                "firefox" => new FirefoxDriver(),
                _ => throw new Exception("Invalid Browser name")
            };
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            return driver;
        }
    }
}
