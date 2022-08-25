using Elements;
using OpenQA.Selenium;

namespace CustomFrameworkPOC.PageObject.Elements
{
    public class BaseElement
    {
        protected ElementService Element;
        protected IWebDriver driver;
        public BaseElement()
        {
            driver = ServiceRegister.Browser.GetWebDriver();
            Element = new ElementService(driver);
        }
    }
}
