using CoreServices;
using CoreServices.ReportService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Elements
{
    public abstract class WebElementExtension
    {
        private WebDriver driver;
        private By by;

        private WebDriverWait wait;
        protected WebElementExtension(WebDriver driver, By by)
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
        public bool WaitForElementToDisappear(int maxSec = 60)
        {
            wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementInVisible());
        }

    }
}
