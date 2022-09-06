using OpenQA.Selenium;
using System;

namespace Elements
{
    public class Hyperlink : WebElement
    {
        private IWebDriver driver;
        public Hyperlink(WebDriver driver, By by) : base(driver, by)
        {
            this.driver = driver;
        }
        public void Click()
        {
            try
            {
                _webElement.Click();
            }
            catch (ElementClickInterceptedException e)
            {
                JsClick();
            }
        }

        public void JsClick()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", _webElement);
        }
    }
}
