using CustomFrameworkPOC.Pages;
using DriverManager;
using Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public class Page
    {

        public Page(DriverFactory instance)
        {
            this.instance = instance;
            Element = GetElementService(instance);
            spinner = new Spinner(instance, Element);
        }
        public TextField ActiveGridTitle(string title) => Element.CreateElementByXpath<TextField>($"//*[contains(@class,'ng-binding active')][contains(text(),'{title}')]");
        private static ElementService GetElementService(DriverFactory instance)
        {
            return new ElementService(instance);
        }

        public void WaitForSpinner(bool shouldBe = false, int waitTill = 60)
        {
            IJavaScriptExecutor j = (IJavaScriptExecutor)instance.getDriver();
            if (j.ExecuteScript("return document.readyState").ToString().Equals("complete"))
            {
                spinner.SpinnerIcon.IsDisplayed(shouldBe, waitTill);
            }
        }

        protected bool WaitForURLToBeMatch(string url, int maxSec =60)
        {
            WebDriverWait wait = new WebDriverWait(instance.getDriver(), TimeSpan.FromSeconds(maxSec));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.Timeout = TimeSpan.FromSeconds(maxSec);
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(url));

        }

        protected ElementService Element;
        protected DriverFactory instance;
        protected Spinner spinner;
    }
}
