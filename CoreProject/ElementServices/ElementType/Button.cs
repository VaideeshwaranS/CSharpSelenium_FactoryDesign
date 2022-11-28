using OpenQA.Selenium;
using System;
using static Elements.WebElementExtension;

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

        
    }
}
