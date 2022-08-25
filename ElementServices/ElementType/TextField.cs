using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace Elements
{
     public class TextField : WebElement
    {
        public TextField(WebDriver driver, By by) : base(driver, by)
        {
        }

        public string GetText()
        { 
            return _webElement.Text.Trim();
        }

    }
}
