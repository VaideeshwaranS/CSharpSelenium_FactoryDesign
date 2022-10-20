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

        #region Spinner 
        public Button LoadingIcon => Element.CreateElementByXpath<Button>("//div[@class='k-loading-image']| //div[@class='circle-loader'] | //div[@class='spinner']");
        #endregion
        public Hyperlink Equipment => Element.CreateElementByID<Hyperlink>("nav-link-Admin.Equipment");
        public Hyperlink Facilities => Element.CreateElementByID<Hyperlink>("nav-link-Admin.Facilities");

    }
}
