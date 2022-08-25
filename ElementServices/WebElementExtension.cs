using CustomFrameworkPOC;
using CustomFrameworkPOC.ReportService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

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

        public IWebElement FindElementInSeconds(int maxSec = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxSec));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementExists());
        }

        private Func<IWebDriver, IWebElement> WaitTillElementExists()
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by);
        }
    }
}
