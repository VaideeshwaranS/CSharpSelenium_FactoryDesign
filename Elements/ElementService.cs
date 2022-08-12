using DriverManager;
using OpenQA.Selenium;
using System;


namespace Elements
{
    public class ElementService
    {
        DriverInstance instance;
             
        public ElementService(DriverInstance instance)
        {
            this.instance = instance;
           
        }
        public T CreateElement<T>(By by)
        {
           return (T)Activator.CreateInstance(typeof(T), instance.driver, by);
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
