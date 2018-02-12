using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PetClinic.POM_Sites;
using TechTalk.SpecFlow;

namespace PetClinic.Steps
{
    [Binding]
    public class TheNewPet
    {
        private IWebDriver driver;

        private FindOwners findOwners;
        private OwnerInformation ownerInformation;
        private NewPet newPet;

        public TheNewPet()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            this.findOwners = new FindOwners(driver);
            this.ownerInformation = new OwnerInformation(driver);
            this.newPet = new NewPet(driver);
        }

        [When(@"I click Add New Pet button")]
        public void WhenIClickAddNewPetButton()
        {
            ownerInformation.AddNewPetButton.Click();
        }

        [Then(@"The New Pet window should be displayed and title should contain ""(.*)""")]
        public void ThenTheNewPetWindowShouldBeDisplayedAndTitleShouldContain(string titleNewPet)
        {
            newPet.WaitForPageTitle(titleNewPet);
        }

        [Then(@"I am able to type the new data as ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenIAmAbleToTypeTheNewDataAs(string petName, string birthDay, string type)
        {
            newPet.AddNewPet(petName, birthDay, type);
        }

        [Then(@"When I click Add Pet button the new pet should be added to the owner")]
        public void ThenWhenIClickAddPetButtonTheNewPetShouldBeAddedToTheOwner()
        {
            newPet.PetButton.Click();
            CollectionAssert.AreEqual(newPet.AddedNewPet(), newPet.ExpectedNewPet());
        }


        


    }
}
