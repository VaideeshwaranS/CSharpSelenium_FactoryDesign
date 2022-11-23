using OpenQA.Selenium;

namespace Elements
{
    public class RadioButton : WebElement
    {
        public RadioButton(IWebDriver driver, By by) : base(driver, by)
        {
        }
        public RadioButton(IWebDriver driver, IWebElement element, By by) : base(driver, element, by)
        {
        }

        public void SelectOption()
        {
            if (!isSelected())
                _webElement.Click();
        }

        public bool isSelected()
        {
            return _webElement.Selected;
        }
    }
}

