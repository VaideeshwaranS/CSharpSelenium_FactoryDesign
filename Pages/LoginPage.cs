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

        public InputField Username => Element.CreateElementByID<InputField>("user-name");
        public InputField Password => Element.CreateElementByID<InputField>("password");
        public Button Loginbutton => Element.CreateElementByID<Button>("login-button");

        public void PerformanceofLoginToSauceDemo()
        {
            Username.SendKeysWithClear("standard_user");
            Password.SendKeysWithClear("secret_sauce");
            var metricsResponse = instance.CreateChromeDevToolSession();
            Loginbutton.Click();
            var metrics = metricsResponse.Result.Metrics;
            foreach (Metric metric in metrics)
            {
                Console.WriteLine("{0} = {1}", metric.Name, metric.Value);
            }
        }
    }
}
