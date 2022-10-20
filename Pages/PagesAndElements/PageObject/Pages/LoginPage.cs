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
        public void PressContinue()
        {
            report.LogReport(Status.Info, $"Clicked on Login Button ");
            page.Continuebutton.Click();
        }
        public void ClickLogin()
        {
            report.LogReport(Status.Info, $"Clicked on Login Button ");
            page.Next.Click();
            
            WaitForLoadingIcon();
            

        }
        public UsersPage LoginToApp()
        {
            EnterUsername("adminuat");
            PressContinue();
            EnterPassword("Test@1234567");
            ClickLogin();
            return new UsersPage();
        }

    }
}
