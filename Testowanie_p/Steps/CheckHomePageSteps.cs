using NUnit.Framework;
using PetClinic.POM_Sites;
using PetClinic.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
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
            //var homePage = new Home(WebBrowser.Current);
            //var homePage = new Home(driver);
            //home = new Home(driver);
            home.Navigate();
            //homePage.Navigate();
        }

        [Then(@"The ""(.*)"" text should be visible and picture should be displayed")]
        public void ThenTheTextShouldBeVisibleAndPictureShouldBeDisplayed(string textttt)
        {
            //var homePage = new Home(WebBrowser.Current);
            //var homePage = new Home(driver);
            //var ddd = homePage.WelcomeText.Text;
            //Assert.AreEqual(homePage.CheckText(), textttt);
            Assert.AreEqual(home.WelcomeText.Text, textttt);
            Assert.IsTrue(home.CheckPicture());
        }


    }
}
