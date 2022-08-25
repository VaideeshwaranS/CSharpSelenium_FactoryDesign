using CustomFrameworkPOC.Pages;
using DriverManager;
using Pages;
using System;

namespace Pages
{
    public class SauceDemoApplication 
    {
        DriverFactory instance;
        public SauceDemoApplication(DriverFactory instance)
        {
            this.instance = instance;
        }

        public void launchApp()
        {
            instance.getDriver().Navigate().GoToUrl("https://cs-simng-web-qa.azurewebsites.net/");
        }
        public LoginPage _loginpage => new LoginPage(instance);
        public ProductsPage _productsPage => new ProductsPage(instance);
        public Dashboard _dashboard => new Dashboard(instance);
        public void CloseApp()
        {
            instance.CloseDriver();
        }
    }
}
