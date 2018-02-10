using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PetClinic.POM_Sites;
using TechTalk.SpecFlow;

namespace PetClinic.Steps
{
    [Binding]
    public class FindInvalidPetOwner
    {
        private IWebDriver driver;

        //private Home home;
        private FindOwners findOwners;
        private OwnerInformation ownerInformation;

        public FindInvalidPetOwner()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
          //this.home = new Home(driver);
            this.findOwners = new FindOwners(driver);
            this.ownerInformation = new OwnerInformation(driver);
        }

        //[Given(@"I have logged to the application")]
        //public void GivenIHaveLoggedToTheApplication()
        //{
        //    //var homePage = new Home(WebBrowser.Current);
        //    //var homePage = new Home(driver);
        //    //home = new Home(driver);
        //    home.Navigate();
        //    //homePage.Navigate();
        //}


        //[When(@"When I click ""(.*)"" tab the appropirate view should be opened")]
        //public void WhenIClickTabTheAppropirateViewShouldBeOpened(string findOwnerTab)
        //{
        //   findOwners.FindOwnerTab.Click();
        //}
        [Given(@"I have moved to Find Owner tab")]
        public void GivenIHaveMovedToFindOwnerTab()
        {
               findOwners.FindOwnerTab.Click();
        }



        [When(@"When I click Find Owner tab the appropirate view should be opened")]
        public void WhenWhenIClickFindOwnerTabTheAppropirateViewShouldBeOpened()
        {
            findOwners.FindOwnerTab.Click();
        }

        [When(@"When I type \""([^\""]*)\"" and click FindOwnerButton button")]
        public void WhenITypeAndClickButton(string ownerName)
        {
            //var findOwner = new FindOwners(driver);
            //findOwner.TypeOwner(ownerName);
            //findOwner.FindOwnerButton.Click();
            findOwners.TypeOwner(ownerName);
            findOwners.FindOwnerButton.Click();
        }

        [Then(@"The error text message should be displayed")]
        public void ThenTheErrorTextMessageShouldBeDisplayed()
        {
             //var findOwner = new FindOwners(driver);
             Assert.AreEqual(findOwners.IncorrectValue.Text, "has not been found");
        }

        [Then(@"The valid user should be found")]
        public void ThenTheValidUserShouldBeFound()
        {
           Assert.AreEqual(findOwners.Driver.Url, "http://localhost:8080/petclinic/owners/8");
        }

        [Then(@"When I click on Edit Owner button the new owner window should be dispalyed")]
        public void ThenWhenIClickOnEditOwnerButtonTheNewOwnerWindowShouldBeDispalyed()
        {
            ownerInformation.EditOwner.Click();
        }

        [Then(@"I type the new data as ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenITypeTheNewDataAs(string firstName, string lastName, string address, string city, string telephone)
        {
            ownerInformation.EditPetOwner(firstName, lastName, address, city, telephone);
        }


        [Then(@"When I click Update Owner button the new data should be saved")]
        public void ThenWhenIClickUpdateOwnerButtonTheNewDataShouldBeSaved()
        {
            ownerInformation.OwnerDataAfterUpdate.Click();
        }



    }


}
