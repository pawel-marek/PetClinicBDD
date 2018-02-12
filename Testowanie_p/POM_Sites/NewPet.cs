using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PetClinic.Helpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PetClinic.POM_Sites
{
    public class NewPet : BaseClass
    {
        public NewPet(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement PetName => Driver.FindElement(By.Id("name"));

        public IWebElement BirthDate => Driver.FindElement(By.Id("birthDate"));

        public IWebElement Type => Driver.FindElement(By.Id("type"));

        public IWebElement WaitClassElement => Driver.FindElement(By.Id("ui-datepicker-div"));

        public NewPet AddNewPet(string petName, string birthDate, string type)
        {
            SelectElement dropdown = new SelectElement(Type);
            dropdown.SelectByText(type);

            SendText(PetName, petName);

            SendText(BirthDate, birthDate);
            BirthDate.SendKeys(Keys.Tab);

            InvisibilityOfElementLocated(By.XPath("//*[@id='ui-datepicker-div']"));

            return this;
        }

        public IWebElement PetButton => Driver.FindElement(By.XPath("/html/body/div[1]/form/div[5]/button"));

        public IWebElement Pet => Driver.FindElement(By.XPath("//html/body/div/table[3]/tbody/tr/td[1]/dl"));

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

