using OpenQA.Selenium;
using System;

namespace Elements
{
    public class Hyperlink : WebElement
    {
        
        public Hyperlink(IWebDriver driver, By by) : base(driver, by)
        {
        }
        public Hyperlink(IWebDriver driver, IWebElement element, By by) : base(driver, element, by)
        {
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
