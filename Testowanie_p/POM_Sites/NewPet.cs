using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PetClinic.Helpers;
using PetClinic.Tests;

namespace PetClinic.POM_Sites
{
    public class NewPet : BaseClass
    {
        public NewPet(IWebDriver driver) : base(driver)
        {
        }

        public string FindNewPetUrl()
        {
            return MainUrl() + "/petclinic/owners/8/pets/new.html";
        }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement PetName { get; set; }

        [FindsBy(How = How.Id, Using = "birthDate")]
        public IWebElement BirthDate { get; set; }

        [FindsBy(How = How.Id, Using = "type")]
        public IWebElement Type { get; set; }

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        public IWebElement WaitClassElement { get; set; }

        //public NewPet AddNewPet(string petName, string birthDate, string type)
        //{
        //    SelectElement dropdown = new SelectElement(Type);
        //    dropdown.SelectByText(type);

        //    SendText(PetName, petName);

        //    SendText(BirthDate, birthDate);
        //    BirthDate.SendKeys(Keys.Tab);               

        //    InvisibilityOfElementLocated(By.XPath("//*[@id='ui-datepicker-div']"));

        //    return this;
        //}

        internal NewPet AddNewPet(string petName, string birthDate, string type)
        {
            SendText(PetName, petName);

            SendText(BirthDate, birthDate);
            BirthDate.SendKeys(Keys.Tab);

            SelectElement dropdown = new SelectElement(Type);
            switch (type)
            {
                case "hamster":
                    dropdown.SelectByText("hamster");
                    break;
                case "bird":
                    dropdown.SelectByText("bird");
                    break;
                case "cat":
                    dropdown.SelectByText("cat");
                    break;
                case "lizard":
                    dropdown.SelectByText("lizard");
                    break;
                case "snake":
                    dropdown.SelectByText("snake");
                    break;
                default:
                    break;
            }
            return this;
        }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/form/div[5]/button")]
        public IWebElement PetButton { get; set; }

        //public NewPet ClickNewPet()
        //{       
        //    ClickOnElement(PetButton);

        //    return new NewPet(driver);
        //}
        
        [FindsBy(How = How.XPath, Using = "//html/body/div/table[3]/tbody/tr/td[1]/dl")]
        public IWebElement Pet { get; set; }

        public List<string> AddedNewPet()
        {
            var targetText = new List<string>();
            string[] lines = Regex.Split(Pet.Text, "\r\n");
            foreach (var VARIABLE in lines)
            {
                targetText.Add(VARIABLE);
            }

            return targetText;
        }

        public List<string> ExpectedNewPet()
        {
            XmListStructure resultDataStructure = new XmListStructure();
            var targetItemsList = resultDataStructure.ParseXml("/Items/ExpectedNewPet/Value");

            return targetItemsList;
        }

    }
}

