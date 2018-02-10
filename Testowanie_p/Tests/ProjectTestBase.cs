
//using System;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using PetClinic.Helpers;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PetClinic.POM_Sites;


//namespace PetClinic.Tests
//{
//    [TestFixture]
//    public class ProjectTestBase
//    {
//        public IWebDriver Driver { get; private set; }

       
//        [OneTimeSetUp]
//        public void SetUp()
//        {
            
           
//            WebDriverFactory selectDriver = new WebDriverFactory();
            
//            Driver = selectDriver.Create(BrowserType.Chrome);
//            StartServer.serverStart();

          


//        }

        


//        [OneTimeTearDown]
//        public void TearDown()
//        {
//            DriverExtensions.TakeScreenshotOnFailure(Driver);
//            Driver.Quit();
//            StartServer.ServerStop();
//        }
//    }
//}
