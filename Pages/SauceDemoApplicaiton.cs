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
            instance.getDriver().Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        public LoginPage _loginpage => new LoginPage(instance);
        public ProductsPage _productsPage => new ProductsPage(instance);
        public void CloseApp()
        {
            instance.CloseDriver();
        }
    }
}
