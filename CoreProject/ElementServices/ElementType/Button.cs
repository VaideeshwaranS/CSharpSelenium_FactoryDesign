using OpenQA.Selenium;
using System;

namespace Elements
{
    public class Button : WebElement
    {
     
        public Button(WebDriver driver, By by) : base(driver, by)
        {
            
        }

        public Button(IWebDriver driver, IWebElement element, By by) : base(driver, element, by)
        {
        }

        public void Click(int maxSec = 60)
        {
            WaitForElementClickable(maxSec);
            try
            {
                if (Enabled)
                    _webElement.Click();
            } catch (Exception e)
            {
                JSClick();//to be 
            }
        }

        public void JSClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", _webElement);
        }
    }
}
