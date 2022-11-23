using OpenQA.Selenium;


namespace Elements
{
   public abstract class WebElement : WebElementExtension
    {
        protected IWebDriver driver;
        private By by;
        public WebElement(IWebDriver driver, By by) : base(driver, by)
        {
            this.driver = driver;
            this.by = by;
        }

        public WebElement(IWebDriver driver, IWebElement element, By by) : this(driver, by)
        {
           _webElement = element;
        }
        public IWebElement _webElement
        {
            get => FindElementInSeconds();

            set => _webElement = value;
        }

        public bool Enabled => _webElement.Enabled;

        public bool isDisplayed(bool isExist = true, int waitSecs = 60)
        {
            if (!isExist)
            {
                try
                {
                    return WaitForElementToDisappear(waitSecs);
                }
                catch
                {
                    return false;
                }
                
            }
            else
            {
                FindElementInSeconds(waitSecs);
                if (_webElement.Displayed)
                    return true;
                else
                    return false;
            }

        }

        /*protected T FindChildElementByXpath<T>(string childLocator) where T: WebElement
        {
            return 
        }*/
    }
}
