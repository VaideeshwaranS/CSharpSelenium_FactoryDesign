using OpenQA.Selenium;


namespace Elements
{
    public class InputField : WebElement
    {
        public InputField(IWebDriver driver, By by) : base(driver, by)
        {
        }
        public InputField(IWebDriver driver, IWebElement element, By by) : base(driver, element, by)
        {
        }
        public void SendKeysWithClear(string text)
        {
            _webElement.Clear();
            _webElement.SendKeys(text);
        }

        public void SendKeysWithEsc(string text)
        {
            _webElement.Clear();
            _webElement.SendKeys(text);
            _webElement.SendKeys(Keys.Escape);
        }
        public void SendKeysToInput(string text)
        {
            FindChildElementByXpath<InputField>("//input").SendKeysWithClear(text);
        }
    }
}
