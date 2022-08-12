using OpenQA.Selenium;

namespace Elements
{
    public class Hyperlink : WebElement
    {
        public Hyperlink(WebDriver driver, By by) : base(driver, by)
        {
        }
        public void Click()
        {
            _webElement.Click();
        }

    }
}
