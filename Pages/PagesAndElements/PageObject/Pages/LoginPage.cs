using AventStack.ExtentReports;
using PageObject.Elements;

namespace PageObject.Pages
{
    public class LoginPage : Page<Login>
    {
        public void EnterUsername(string username)
        {
            report.LogReport(Status.Info, $"Enter the username {username} ");
            page.Username.SendKeysWithClear(username);
        }
        public void EnterPassword(string password)
        {
            report.LogReport(Status.Info, $"Enter the password {password} ");
            page.Password.SendKeysWithClear(password);
        }
        public void ClickLogin()
        {
            report.LogReport(Status.Info, $"Clicked on Login Button ");
            page.Loginbutton.Click();
        }
        public void LoginToApp()
        {
            EnterUsername("performance_glitch_user");
            EnterPassword("secret_sauce");
            ClickLogin();
        }

    }
}
