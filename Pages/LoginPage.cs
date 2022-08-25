using CustomFrameworkPOC.Pages;
using DriverManager;
using Elements;
using OpenQA.Selenium.DevTools.V104.Performance;
using System;

namespace Pages
{
    public class LoginPage : Page
    {
        public LoginPage(DriverFactory instance) : base(instance)
        {
        }

        public InputField Username => Element.CreateElementByID<InputField>("login-username");
        public InputField Password => Element.CreateElementByID<InputField>("login-pwd");
        public Button Loginbutton => Element.CreateElementByID<Button>("login-btn");
        public Button NextButton => Element.CreateElementByID<Button>("next-btn");
        public void LoginToApp()
        {
            Username.SendKeysWithClear("LR546");
            NextButton.Click();
            WaitForSpinner(false);
            Password.SendKeysWithClear("Password@123");
            Loginbutton.Click();
            WaitForURLToBeMatch("https://cs-simng-web-qa.azurewebsites.net/dashboard");
            WaitForSpinner(false);
        }

      
    }
}
