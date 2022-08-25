using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Threading.Tasks;

namespace Elements
{
    public abstract class WebElement : WebElementExtension
    {
        private IWebDriver driver;
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

        bool Displayed => _webElement.Displayed;


        public void WaitAndClick(bool useJS = false, int waitTill = 60)
        {
            WaitForElementClickable(waitTill);
            try
            {
                if (useJS && (Enabled || Displayed)) JsClick();
                else _webElement.Click();
            } catch (ElementClickInterceptedException)
            {
                JsClick();
            }

        }

        public void JsClick()
        {
            var jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", _webElement);

        }

        public void ScrollToElement()
        {
            var jse = (IJavaScriptExecutor)driver;
            //jse.ExecuteScript("arguments[0].scrollIntoView(true,{ behavior: 'smooth', block: 'nearest', inline: 'start'});", _webElement);
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", _webElement);
           
        }

        public void MoveToElement()
        {
            ScrollToElement();
            Actions a = new Actions(driver);
            a.MoveToElement(_webElement);
            a.Perform();
        }
        
    }
}
