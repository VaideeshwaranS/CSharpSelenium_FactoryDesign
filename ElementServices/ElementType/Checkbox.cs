using OpenQA.Selenium;

namespace Elements
{
    public class Checkbox : WebElement
    {
        public Checkbox(WebDriver driver, By by) : base(driver, by)
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

