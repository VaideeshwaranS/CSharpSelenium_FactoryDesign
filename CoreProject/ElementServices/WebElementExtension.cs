using CoreServices;
using CoreServices.ReportService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Elements
{
    public abstract class WebElementExtension
    {
        private IWebDriver driver;
        private By by;

        private WebDriverWait wait;
        protected WebElementExtension(IWebDriver driver, By by)
        {
            this.driver = driver;
            this.by = by;
        }

        public IWebElement FindElementInSeconds(int maxSec = 60)
        {
            wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementExists());
        }

        private Func<IWebDriver, IWebElement> WaitTillElementExists()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by);
        }

        private Func<IWebDriver, bool> WaitTillElementInVisible()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by);
        }
        private Func<IWebDriver, IWebElement> WaitTillElementClickable()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by);
        }
        public bool WaitForElementToDisappear(int maxSec = 60)
        {
            wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementInVisible());
        }

        public IWebElement WaitForElementClickable(int maxSec = 60)
        {
            wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementClickable());
        }

        public IWebElement WaitForElementToBePresent(int maxSec = 60)
        {
            wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public T FindChildElementByXpath<T>(string id)
        {
            ElementService element = new ElementService(driver);
            return element.CreateElementByXpath<T>(by.Criteria + id);
            
        }

        public List<T> FindAllChildElementByXpath<T>(string id)
        {
            ElementService element = new ElementService(driver);
            return element.CreateAllElementByXpath<T>(by.Criteria + id);

        }
    }
}
