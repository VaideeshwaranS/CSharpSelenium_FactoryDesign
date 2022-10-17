using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V104.Performance;
using System;
using System.Threading.Tasks;
using DevToolVersion = OpenQA.Selenium.DevTools.V104;
using DevToolsSessionDomain = OpenQA.Selenium.DevTools.V104.DevToolsSessionDomains;
using Network = OpenQA.Selenium.DevTools.V104.Network;
using CoreServices.Performance;
using System.Collections.Generic;

namespace CoreServices.DriverManager
{
    public interface IDriverService
    {
        IWebDriver GetWebDriver();
        void CloseDriver();
        void NavigateBack();
        void Refresh();
        Task CreateDevToolsSessionAsync();
        Task<PerformanceMetrics>  GetPerformanceMetricsAsync();
        void CloseDevToolsSession();
    }
    public class DriverService : IDriverService
    {
        private IWebDriver driver;
        private IDevTools devTools;
        private DevToolsSession session;
        public DriverService(string browser)
        {
            var service = ChromeDriverService.CreateDefaultService();
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + "chromedriver.log");
            service.LogPath = AppDomain.CurrentDomain.BaseDirectory + "chromedriver.log";
            service.EnableVerboseLogging = true;
            var options = new ChromeOptions();

            driver = browser switch
            {
                "chrome" => new ChromeDriver(service, options),
                _ => throw new Exception("Invalid Browser name")
            };
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }
        public IWebDriver GetWebDriver()
        {
            return driver;
        }
               
        public  void CloseDriver() => driver.Close();

        public  void NavigateBack() => driver.Navigate().Back();

        public  void Refresh() => driver.Navigate().Refresh();

        public async Task CreateDevToolsSessionAsync()
        {
            devTools = driver as IDevTools;
            session = devTools.GetDevToolsSession();
            /*
            var fetch = session.GetVersionSpecificDomains<DevToolsSessionDomain>().Fetch;
            var enableCommandSettings = new DevToolVersion.Fetch.EnableCommandSettings();
            var requestPattern = new DevToolVersion.Fetch.RequestPattern();
            requestPattern.RequestStage = DevToolVersion.Fetch.RequestStage.Response;
            requestPattern.ResourceType = Network.ResourceType.Document;
            enableCommandSettings.Patterns = new DevToolVersion.Fetch.RequestPattern[] { requestPattern };

            await fetch.Enable(enableCommandSettings);

            void RequestIntercepted(object sender, DevToolVersion.Fetch.RequestPausedEventArgs e)
            {

                
                fetch.ContinueRequest(new DevToolVersion.Fetch.ContinueRequestCommandSettings()
                {
                    RequestId = e.RequestId
                });
            }
            fetch.RequestPaused += RequestIntercepted;
            */
            await session.SendCommand(new EnableCommandSettings());
            
        }

        public async Task<PerformanceMetrics> GetPerformanceMetricsAsync()
        {
            var metricsResponse = await session.SendCommand<GetMetricsCommandSettings, GetMetricsCommandResponse>(
            new GetMetricsCommandSettings());
            CloseDevToolsSession();
            PerformanceMetrics perfmetrics = new PerformanceMetrics();
            Dictionary<string, double> dict = new Dictionary<string, double>();
            foreach (Metric metric in metricsResponse.Metrics)
            {
                dict.Add(metric.Name, metric.Value);
            }
            perfmetrics.TotalTimeforNavigation = Math.Round((dict["Timestamp"] - dict["NavigationStart"]) / 1000,3);
            perfmetrics.DomLoaded = Math.Round((dict["DomContentLoaded"] - dict["NavigationStart"]) / 1000,3);
            perfmetrics.TotalScriptDuration = Math.Round(dict["ScriptDuration"], 3);
            perfmetrics.FirstMeaningfulPaintDuration = (dict["FirstMeaningfulPaint"] > 0 ) ?
               Math.Round((dict["FirstMeaningfulPaint"] - dict["NavigationStart"]) / 1000, 3) : dict["FirstMeaningfulPaint"];

            return perfmetrics;
        }

        public void CloseDevToolsSession()
        {
            devTools.CloseDevToolsSession();
        }

    }
}
