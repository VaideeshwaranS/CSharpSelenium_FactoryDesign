using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Elements
{
    public class ElementService
    {
        private IWebDriver driver;
             
        public ElementService(IWebDriver driver)
        {
            this.driver = driver;
           
        }
        public T CreateElement<T>(By by)
        {
            var ele = (T)Activator.CreateInstance(typeof(T), new object[] { driver, by });
            return ele;
        }

        public T CreateElementByXpath<T>(string id)
        {
            By by = By.XPath(id);
            return CreateElement<T>(by);
        }
        public T CreateElementByID<T>(string id)
        {
            By by = By.Id(id);
            return CreateElement<T>(by);
        }

        public List<T> CreateAllElementByXpath<T>(string id)
        {
            By by = By.XPath(id);
            var result = driver.FindElements(by);
            var resultElements = new List<T>();
            foreach (var element in result)
            {
                try
                {
                    var ele = (T)Activator.CreateInstance(typeof(T),new object[] { driver, element, by });
                    resultElements.Add(ele);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
            }
            
            return resultElements;
        }

    }
}
