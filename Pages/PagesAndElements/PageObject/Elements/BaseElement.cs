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
        public Button MatLoader => Element.CreateElementByXpath<Button>("//mat-spinner[@role='progressbar']");
        public TextField KendoLoading => Element.CreateElementByXpath<TextField>("//div[@class='circle-loader-text'][normalize-space(text()='Loading')]");
        #endregion

        public TextField PageTitle => Element.CreateElementByXpath<TextField>("//span[@class='page-header']/span");
        public Button InnerTab(string tabName) => Element.CreateElementByXpath<Button>($"//tabset//li[contains(@class,'nav-item')]//span/span[normalize-space()='{tabName}']");
        public TextField ToastMessage => Element.CreateElementByXpath<TextField>($"//div[@id='toast-container']//span[contains(@class,'alert-text')]");
    }
}