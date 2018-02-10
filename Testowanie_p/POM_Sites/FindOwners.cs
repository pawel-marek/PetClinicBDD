using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PetClinic.Helpers;
using PetClinic.Tests;


namespace PetClinic.POM_Sites
{
    public class FindOwners : BaseClass
    {
        //private IWebDriver driver;

        public FindOwners(IWebDriver driver) : base(driver)
        {
            //this.Driver = WebBrowser.Current;
            this.Driver = driver;
        }

      

        public IWebElement LastName => Driver.FindElement(By.XPath("//*[@id=\"lastName\"]"));


        protected WebDriverWait Wait;

        //OOP
        internal FindOwners TypeOwner(string ownerName)
        {
            SendText(LastName, ownerName);
            return this;
        }
        //internal FindOwners TypeValidOwner(string validOwnerName)
        //{
        //    SendText(LastName, validOwnerName);
        //    return this;
        //}
        //internal FindOwners Owner(string ownerName)
        //{
        //    SendText(LastName, ownerName);
        //    return this;
        //}

        public IWebElement FindOwnerButton => Driver.FindElement(By.CssSelector("#search-owner-form > fieldset > div.form-actions > button"));

        public IWebElement FindOwnerTab => Driver.FindElement(By.XPath("//*[contains(text(),'Find owners')]"));



        //public OwnerInformation ClickFindOwner()
        //{
        //    ClickOnElement(FindOwnerButton);

        //    return new OwnerInformation(driver);
        //}


        public IWebElement IncorrectValue => Driver.FindElement(By.ClassName("help-inline"));

    }
}
