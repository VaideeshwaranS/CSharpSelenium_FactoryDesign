using DriverManager;
using OpenQA.Selenium;
using System;


namespace Elements
{
    public class ElementService
    {
        DriverFactory instance;
             
        public ElementService(DriverFactory instance)
        {
            this.instance = instance;
           
        }
        public T CreateElement<T>(By by)
        {
           return (T)Activator.CreateInstance(typeof(T), instance.getDriver(), by);
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


    }
}
