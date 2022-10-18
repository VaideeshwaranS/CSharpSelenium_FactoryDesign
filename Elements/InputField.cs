using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace Elements
{
    public class InputField : WebElement
    {
        private IWebDriver driver;
        public InputField(WebDriver driver, By by) : base(driver, by)
        {
            this.driver = driver;
        }

        public void SendKeysWithClear(string text)
        {
            if (_webElement.Displayed)
            {
                _webElement.Clear();
                _webElement.SendKeys(text);
            }
           
        }

        public void enterDate(string value)
        {
            MoveToElement();
            string[] date = new string[3];
            if (value.Contains("/")) date = value.Split("/");
            if (value.Contains(".")) date = value.Split(".");
            if (value.Contains("-")) date = value.Split("-");
            Actions act = new Actions(driver);
            act.Click(_webElement)
              .Pause(TimeSpan.FromMilliseconds(500))
              .SendKeys(Keys.ArrowLeft)
              .Pause(TimeSpan.FromMilliseconds(500))
              .SendKeys(Keys.ArrowLeft)
              .Pause(TimeSpan.FromMilliseconds(500))
              .SendKeys(date[0])
              .Pause(TimeSpan.FromMilliseconds(500))
              .SendKeys(date[1])
              .Pause(TimeSpan.FromMilliseconds(500))
              .SendKeys(date[2])
              .Build()
              .Perform();
        }

    }
}
