using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V104.Performance;
using System;
using System.Threading.Tasks;

namespace DriverManager
{
    public sealed class DriverFactory
    {
        private IDriverService _driverService;
        private IWebDriver driver;
        static DriverFactory() { }
        public IDriverService driverService
        {
            set
            {
                _driverService = value;
                driver = _driverService.GetWebDriver();
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

        public void CloseDriver() => driver.Close();

        public void NavigateBack() => driver.Navigate().Back();

        public void Refresh() => driver.Navigate().Refresh();

        public Task<GetMetricsCommandResponse> CreateChromeDevToolSession()
        {
            IDevTools devTools = driver as IDevTools;
            DevToolsSession session = devTools.GetDevToolsSession();
            session.SendCommand<EnableCommandSettings>(new EnableCommandSettings());
            var metricsResponse = session.SendCommand<GetMetricsCommandSettings, GetMetricsCommandResponse>(
            new GetMetricsCommandSettings());
            return metricsResponse;
        }
    }
}
