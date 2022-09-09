using CoreServices;
using Elements;
using OpenQA.Selenium;

namespace PageObject.Elements
{
    public class BaseElement
    {
        protected ElementService Element;
        protected IWebDriver driver;
        public BaseElement()
        {
            driver = ServiceRegister.Browser.GetWebDriver();
            Element = ServiceRegister.Element;
        }
    }
}
