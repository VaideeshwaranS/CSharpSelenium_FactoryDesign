using DriverManager;
using Pages;

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
    }
}
