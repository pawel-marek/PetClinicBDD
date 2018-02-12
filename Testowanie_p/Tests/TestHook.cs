using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace PetClinic.Tests
{
    [Binding]
    public sealed class WebBrowser
    {
        
        public IWebDriver driver;
       
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = DriverFactory.ReturnDriver(DriverFactory.DriverType.Chrome);
            ScenarioContext.Current["driver"] = driver;

        }

        [AfterScenario]
        public void AfterScenario()
        {    
            driver.Close();
        }
    }
}
