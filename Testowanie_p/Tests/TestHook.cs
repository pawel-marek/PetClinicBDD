using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PetClinic.Tests
{
    [Binding]
    public sealed class WebBrowser
    {
        //private IWebDriver driver;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public IWebDriver driver;
        //{
        //    get
        //    {
        //        if (!ScenarioContext.Current.ContainsKey("browser"))
        //        {          
        //            //Select Chrome browser
        //            ScenarioContext.Current["browser"] = new ChromeDriver();
        //        }
        //        return (IWebDriver)ScenarioContext.Current["browser"];
        //    }
       // }
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = DriverFactory.ReturnDriver(DriverFactory.DriverType.Chrome);
            ScenarioContext.Current["driver"] = driver;

        }

        [AfterScenario]
        public void AfterScenario()
        {
            //if (ScenarioContext.Current.ContainsKey("browser"))
            //{
            driver.Close();

            //}
        }
    }
}
