using OpenQA.Selenium;


namespace Elements
{
    public class InputField : WebElement
    {
        public InputField(WebDriver driver, By by) : base(driver, by)
        {
        }

        public void SendKeysWithClear(string text)
        {
            _webElement.Clear();
            _webElement.SendKeys(text);
        }

    }
}
