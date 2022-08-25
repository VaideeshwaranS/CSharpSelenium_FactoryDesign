using CustomFrameworkPOC.PerformanceMetrics;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V104.Performance;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DriverManager
{
    public sealed class DriverFactory
    {
        private IDriverService _driverService;
        private IWebDriver driver;
        private IDevTools devTools;
        private DevToolsSession session;


        public IDriverService driverService
        {
            set
            {
                _driverService = value;
                driver = _driverService.GetWebDriver();
                devTools = driver as IDevTools;
            }
            get
            {
                if (driverService == null)
                {
                    throw new Exception("Driver is not initialized");
                }
                else
                {
                    return _driverService;
                }
            }
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void CloseDriver() => driver.Quit();

        public void NavigateBack() => driver.Navigate().Back();

        public void Refresh() => driver.Navigate().Refresh();

        public PerformanceMetricsMap GetPerformanceMetrics()
        {
            
            session = devTools.GetDevToolsSession();
            session.SendCommand(new EnableCommandSettings());
            var metricsResponse = session.SendCommand<GetMetricsCommandSettings, GetMetricsCommandResponse>(new GetMetricsCommandSettings());
            devTools.CloseDevToolsSession();
            Dictionary<string, double> d = new Dictionary<string, double>();
            foreach (Metric m in metricsResponse.Result.Metrics)
            {
                d.Add(m.Name, m.Value);
            }
            PerformanceMetricsMap output = JsonConvert.DeserializeObject<PerformanceMetricsMap>( Newtonsoft.Json.JsonConvert.SerializeObject(d));
            return output;
        }

        public void GetNetworkLog()
        {
            var NetworkLog =  driver.Manage().Logs.GetLog("performance");
           
            foreach (OpenQA.Selenium.LogEntry log in NetworkLog)
            {
                Console.WriteLine(log.Message+" : "+log.Timestamp);
            }
           
        }

        
    }
}
