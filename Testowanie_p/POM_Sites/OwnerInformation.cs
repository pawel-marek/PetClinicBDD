using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PetClinic.Helpers;
using PetClinic.Tests;

namespace PetClinic.POM_Sites
{
    public class OwnerInformation : BaseClass
    {

        public OwnerInformation(IWebDriver driver) : base (driver)
        {
            this.Driver = driver;
        }

        //public string OwnerInformationUrl()
        //{
        //    return MainUrl() + "/petclinic/owners/8";
        //}

        //[FindsBy(How = How.CssSelector, Using = "body > div > table.table.table-striped > tbody > tr:nth-child(1) > td > b")]
        //public IWebElement OwnerData { get; set; }

        public IWebElement OwnerData => Driver.FindElement(By.CssSelector("body > div > table.table.table-striped > tbody > tr:nth-child(1) > td > b"));

        //[FindsBy(How = How.CssSelector,
           // Using = "body > div > table.table.table-striped > tbody > tr:nth-child(5) > td:nth-child(1) > a")]
        public IWebElement EditOwner => Driver.FindElement(By.CssSelector("body > div > table.table.table-striped > tbody > tr:nth-child(5) > td:nth-child(1) > a"));



        //public FindOwners ClickEditOwners()
        //{
        //    ClickOnElement(EditOwner);

        //    return new FindOwners(Driver);
        //}

        //[FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstNameField => Driver.FindElement(By.Id("firstName"));

        //[FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastNameField => Driver.FindElement(By.Id("lastName"));

        //[FindsBy(How = How.Id, Using = "address")]
        public IWebElement AddressField => Driver.FindElement(By.Id("address"));

        //[FindsBy(How = How.Id, Using = "city")]
        public IWebElement CityField => Driver.FindElement(By.Id("city"));

        //[FindsBy(How = How.Id, Using = "telephone")]
        public IWebElement TelephoneField => Driver.FindElement(By.Id("telephone"));

        public OwnerInformation EditPetOwner(string firstName, string lastName, string address, string city, string telephone)
        {
            FirstNameField.Clear();
            SendText(FirstNameField, firstName);

            LastNameField.Clear();
            SendText(LastNameField, lastName);

            AddressField.Clear();
            SendText(AddressField, address);

            CityField.Clear();
            SendText(CityField, city);

            TelephoneField.Clear();
            SendText(TelephoneField, telephone);

            return this;
        }

        //[FindsBy(How = How.CssSelector, Using = "#add-owner-form > div.form-actions > button")]
        public IWebElement UpdateOwner => Driver.FindElement(By.CssSelector("#add-owner-form > div.form-actions > button"));

        //public OwnerInformation ClickUpdateOwner()
        //{
        //    ClickOnElement(UpdateOwner);

        //    return new OwnerInformation(Driver);
        //}

        //[FindsBy(How = How.CssSelector, Using = "body > div > table.table.table-striped > tbody > tr:nth-child(1) > td > b")]
        public IWebElement OwnerDataAfterUpdate => Driver.FindElement(By.XPath("//*[contains(text(),'Update Owner')]"));

        //[FindsBy(How = How.CssSelector, Using = "body > div > table.table.table-striped > tbody > tr:nth-child(5) > td:nth-child(2) > a")]
        public IWebElement AddNewPetButton => Driver.FindElement(By.CssSelector("body > div > table.table.table-striped > tbody > tr:nth-child(5) > td:nth-child(2) > a"));

        //public NewPet AddNewPet()
        //{
        //    ClickOnElement(AddNewPetButton);

        //    return new NewPet(Driver);
        //}

        //[FindsBy(How = How.CssSelector, Using = "a[href*='/petclinic/owners/8/pets/10/visits/new']")]
        public IWebElement AddVisit => Driver.FindElement(By.CssSelector("a[href*='/petclinic/owners/8/pets/10/visits/new']"));

        //public Visit ClickAddNewVisit()
        //{
        //    ClickOnElement(AddVisit);

        //    return new Visit(Driver);
        //}

        //[FindsBy(How = How.XPath, Using = "//html/body/div/table[2]/tbody/tr/td[2]/table/tbody/tr[1]")]
        IList<IWebElement> AddedItems => Driver.FindElements(By.XPath("//html/body/div/table[2]/tbody/tr/td[2]/table/tbody/tr[1]"));

        public List<string> PetVisits()
        {
            var targetText = new List<string>();
            foreach (var VARIABLE in AddedItems)
            {
                string ele = VARIABLE.Text;
                targetText.Add(ele);
            }

            return targetText;
        }

 

    }
}