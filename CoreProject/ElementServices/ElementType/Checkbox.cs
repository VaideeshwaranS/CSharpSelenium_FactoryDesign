using OpenQA.Selenium;

namespace Elements
{
    public class Checkbox : WebElement
    {
        public Checkbox(IWebDriver driver, By by) : base(driver, by)
        {
        }
        public Checkbox(IWebDriver driver, IWebElement element, By by) : base(driver, element, by)
        {
        }
        public void SelectCheckBox(bool select = true)
        {
            if ( (select && !isSelected()) || (!select && isSelected()))
                _webElement.Click();
        }

        public bool isSelected()
        {
            return _webElement.Selected;
        }
    }
}

