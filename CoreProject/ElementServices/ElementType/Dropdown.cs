using OpenQA.Selenium;


namespace Elements
{
    public class Dropdown : WebElement
    {
        public Dropdown(IWebDriver driver, By by) : base(driver, by)
        {
        }
        public Dropdown(IWebDriver driver, OpenQA.Selenium.WebElement element, By by) : base(driver, element, by)
        {
        }
        public void SelectValuesFromNg(string text)
        {
            _webElement.Click();
            FindChildElementByXpath<Button>($"/ng-dropdown-panel//span[contains(.,'{text}')]").Click();
        }

        public void SelectValuesByInput(string text)
        {
            _webElement.Click();
            FindChildElementByXpath<InputField>("//input").SendKeysWithClear(text);
            FindChildElementByXpath<Button>($"/ng-dropdown-panel//span[contains(.,'{text}')]").Click();
        }
    }
}
