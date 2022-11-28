using CoreServices;
using CoreServices.ReportService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Elements
{
    public static class WebElementExtension
    {
        public static IWebElement FindElementInSeconds(this IWebDriver driver,By by ,int maxSec = 60)
        { 
            var wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementExists(by));
        }

        public static List<IWebElement> FindElemenstInSeconds(this IWebDriver driver, By by)
        {
            try
            {
                List<IWebElement> webElements = default;
                webElements = driver.FindElements(by).ToList();
                return webElements;

            }
            catch
            {
                throw new WebDriverTimeoutException($"Element with locator {by.Criteria} not found");
            }
         
        }

        private static Func<IWebDriver, IWebElement> WaitTillElementExists(By by)
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by);
        }

        private static Func<IWebDriver, bool> WaitTillElementInVisible(By by)
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by);
        }
        private static Func<IWebDriver, IWebElement> WaitTillElementClickable(By by)
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by);
        }
        public static bool WaitForElementToDisappear(By by, int maxSec = 60)
        {
            var wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementInVisible(by));
        }

        public static IWebElement WaitForElementClickable(By by, int maxSec = 60)
        {
            var wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(WaitTillElementClickable(by));
        }

        public static IWebElement WaitForElementToBePresent(By by ,int maxSec = 60)
        {
            var wait = ServiceRegister.BrowserWait;
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);

            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static By getByFromElement(this IWebElement element)
        {

            By by = null;
            string[] selectorWithValue = (element.ToString().Split("->")[1].Replace("(?s)(.*)\\]", "$1" + "")).Split(":");

            string selector = selectorWithValue[0].Trim();
            string value = selectorWithValue[1].Trim();

            switch (selector)
            {
                case "id":
                    by = By.Id(value);
                    break;
                case "className":
                    by = By.ClassName(value);
                    break;
                case "tagName":
                    by = By.TagName(value);
                    break;
                case "xpath":
                    by = By.XPath(value);
                    break;
                case "cssSelector":
                    by = By.CssSelector(value);
                    break;
                case "linkText":
                    by = By.LinkText(value);
                    break;
                case "name":
                    by = By.Name(value);
                    break;
                case "partialLinkText":
                    by = By.PartialLinkText(value);
                    break;
                default:
                    throw new Exception("locator : " + selector + " not found!!!");
            }
            return by;
        }
    }
}
