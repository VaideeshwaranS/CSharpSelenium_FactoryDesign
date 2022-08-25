using AventStack.ExtentReports;
using CustomFrameworkPOC.PageObject.Elements;
using CustomFrameworkPOC.ReportService;

namespace CustomFrameworkPOC.PageObject.Pages
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
            EnterUsername("standard_user");
            EnterPassword("secret_sauce");
            ClickLogin();
        }

    }
}
