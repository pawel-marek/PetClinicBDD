using NUnit.Framework;
using OpenQA.Selenium;
using PetClinic.POM_Sites;
using TechTalk.SpecFlow;

namespace PetClinic.Steps
{
    [Binding]
    public sealed class CheckHomePageSteps
    {
        private IWebDriver driver;

        private Home home;

        public CheckHomePageSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            this.home = new Home(driver);
        }

        [Given(@"I have logged to the application")]
        public void GivenIHaveLoggedToTheApplication()
        {        
            home.Navigate();
        }

        [Then(@"The ""(.*)"" text should be visible and picture should be displayed")]
        public void ThenTheTextShouldBeVisibleAndPictureShouldBeDisplayed(string textttt)
        {
            Assert.AreEqual(home.WelcomeText.Text, textttt);
            Assert.IsTrue(home.CheckPicture());
        }


    }
}
