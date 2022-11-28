using CoreServices;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using static Elements.WebElementExtension;

namespace Elements
{
   public abstract class WebElement 
    {
        protected IWebDriver driver;
        protected By by;
        public WebElement(IWebDriver driver, By by) 
        {
            this.driver = driver;
            this.by = by;
        }

        public WebElement(IWebDriver driver, IWebElement element, By by) 
        {
            this.driver = driver;
            this.by = by;
            _webElement = element;
        }
        public IWebElement _webElement
        {
            get => driver.FindElementInSeconds(by);

            set => _webElement = value;
        }

        public bool Enabled => _webElement.Enabled;

        public bool isDisplayed(bool isExist = true, int waitSecs = 60)
        {
            if (!isExist)
            {
                try
                {
                    return WaitForElementToDisappear(by,waitSecs);
                }
                catch
                {
                    return false;
                }
                
            }
            else
            {
                driver.FindElementInSeconds(by,waitSecs);
                if (_webElement.Displayed)
                    return true;
                else
                    return false;
            }

        }
        public void Click(int maxSec = 60)
        {
            WaitForElementClickable(by, maxSec);
            try
            {
                if (Enabled)
                    _webElement.Click();
            }
            catch (Exception e)
            {
                JSClick();//to be 
            }
        }

        public string GetAttribute(string name)
        {
            return _webElement.GetAttribute(name).ToString();
        }
        public void JSClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", _webElement);
        }
        public T FindChildElementByXpath<T>(string id) where T : WebElement
        {
            ElementService element = new ElementService(ServiceRegister.Browser.GetWebDriver());
            return element.CreateElementByXpath<T>(by.Criteria + id);

        }

        public List<T> FindAllChildElementByXpath<T>(string id) where T : WebElement
        {
            ElementService element = new ElementService(ServiceRegister.Browser.GetWebDriver());
            return element.CreateAllElementByXpath<T>(by.Criteria + id);

        }
    }
}
