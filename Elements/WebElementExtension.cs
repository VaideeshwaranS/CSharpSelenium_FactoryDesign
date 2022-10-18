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

        protected WebElementExtension(WebDriver driver, By by)
        {
            this.driver = driver;
            this.by = by;
        }

        protected IWebElement FindElementInSeconds(int maxSec = 60)
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxSec));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementExists());
        }

        private Func<IWebDriver, IWebElement> WaitTillElementExists()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by);
        }

        private Func<IWebDriver, bool> WaitForInvisible()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by);
        }
        private Func<IWebDriver, IWebElement> WaitForVisible()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by);
        }

        private Func<IWebDriver, IWebElement> WaitForClickable()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by);
        }
        private Func<IWebDriver, bool> WaitForURL(string URL)
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(URL);
        }

        protected bool WaitForInvisibilityofElement(int maxSec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxSec));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);
            return wait.Until(WaitForInvisible());
        }

        protected void WaitForElementClickable(int maxSec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxSec));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);
            wait.Until(WaitForVisible());
            wait.Until(WaitForClickable());
        }

        protected bool WaitForVisibilityofElement(int maxSec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxSec));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);
            wait.Until(WaitForVisible());
            return driver.FindElement(by).Displayed;
        }

        

    }
}
