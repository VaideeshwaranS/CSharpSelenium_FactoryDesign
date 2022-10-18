using DriverManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class BaseUITest
    {
        protected DriverFactory instance;
        protected SauceDemoApplication app;

        [TestInitialize]
        public void TestInit()
        {
            instance = new DriverFactory();
            instance.driverService = new DriverService("chrome");
            app = new SauceDemoApplication(instance);
            app.launchApp();
        }

        [TestCleanup]
        public void TestClean()
        {
            app.CloseApp();
        }
    }
}