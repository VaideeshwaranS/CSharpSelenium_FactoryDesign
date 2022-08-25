using OpenQA.Selenium;

namespace Elements
{
    public class Button : WebElement
    {
        public Button(WebDriver driver, By by) : base(driver, by)
        {
        }

        public void Click()
        {
            _webElement.Click();
        }
    }
}
