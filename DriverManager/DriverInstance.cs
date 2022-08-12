using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V103.Performance;
using OpenQA.Selenium.Firefox;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EnableCommandSettings = OpenQA.Selenium.DevTools.V103.Performance.EnableCommandSettings;

namespace DriverManager
{
    public class DriverInstance : DriverFactory
    {
        public  WebDriver driver { get;  set; }
        public  string Browser { get; set; }
       

        public DriverInstance(string Browser)
        {
            this.Browser = Browser;
            CreateDriver();
            
        }
        public override void CreateDriver()
        {
            driver = Browser.ToLower() switch
            {
               "chrome" => new ChromeDriver(),
               "firefox" => new FirefoxDriver(),
                _ => throw new NotImplementedException(),
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
        }

        public override WebDriver getDriver()
        {
            return driver;
        }

        public Task<GetMetricsCommandResponse> CreateChromeDevToolSession()
        {
            IDevTools devTools = driver as IDevTools; 
            DevToolsSession session = devTools.GetDevToolsSession();
            session.SendCommand<EnableCommandSettings>(new EnableCommandSettings());
            var metricsResponse = session.SendCommand<GetMetricsCommandSettings, GetMetricsCommandResponse>(
            new GetMetricsCommandSettings());
            
            return metricsResponse;
        }
        public override void CloseDriver()
        {
            driver.Close();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                System.Diagnostics.Process.Start("CMD.exe", "taskkill /IM chromedriver.exe /F");
            }
        }

        public void LaunchApp()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
           
        }
        
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }
    }
}
