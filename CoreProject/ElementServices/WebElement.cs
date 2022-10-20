using OpenQA.Selenium;


namespace Elements
{
   public abstract class WebElement : WebElementExtension
    {
        private WebDriver driver;
        private By by;
        public WebElement(WebDriver driver, By by) : base(driver, by)
        {
            this.driver = driver;
            this.by = by;
        }

        public IWebElement _webElement
        {
            get => FindElementInSeconds();

            set => _webElement = value;
        }

        bool Enabled => _webElement.Enabled;

        public bool isDisplayed(bool isExist = true, int waitSecs = 60)
        {
            if (!isExist)
            {
                WaitForElementToDisappear(waitSecs);
            }
            if (isExist && _webElement.Displayed)
                return true;
            else
                return false;
           
        }
    }
}
