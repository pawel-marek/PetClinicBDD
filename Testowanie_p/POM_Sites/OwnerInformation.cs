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

        public IWebElement OwnerData => Driver.FindElement(By.CssSelector("body > div > table.table.table-striped > tbody > tr:nth-child(1) > td > b"));

        public IWebElement EditOwner => Driver.FindElement(By.CssSelector("body > div > table.table.table-striped > tbody > tr:nth-child(5) > td:nth-child(1) > a"));

        public IWebElement FirstNameField => Driver.FindElement(By.Id("firstName"));

        public IWebElement LastNameField => Driver.FindElement(By.Id("lastName"));

        public IWebElement AddressField => Driver.FindElement(By.Id("address"));

        public IWebElement CityField => Driver.FindElement(By.Id("city"));

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

        public IWebElement UpdateOwner => Driver.FindElement(By.CssSelector("#add-owner-form > div.form-actions > button"));

        public IWebElement OwnerDataAfterUpdate => Driver.FindElement(By.XPath("//*[contains(text(),'Update Owner')]"));

        public IWebElement AddNewPetButton => Driver.FindElement(By.CssSelector("body > div > table.table.table-striped > tbody > tr:nth-child(5) > td:nth-child(2) > a"));
    
        public IWebElement AddVisit => Driver.FindElement(By.CssSelector("a[href*='/petclinic/owners/8/pets/10/visits/new']"));

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