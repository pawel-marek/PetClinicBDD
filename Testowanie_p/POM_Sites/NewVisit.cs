using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PetClinic.Helpers;
using PetClinic.Tests;

namespace PetClinic.POM_Sites
{
    public class Visit : BaseClass
    {

        public Visit(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "date")]
        public IWebElement Date { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > form > div.form-actions > button")]
        public IWebElement AddVisitClick { get; set; }

        //public OwnerInformation AddNewVist(string visitDate, string description)
        //{
        //    Date.Clear();
        //    SendText(Date, visitDate);
        //    Date.SendKeys(Keys.Tab);

        //    Description.SendKeys(description);

        //    InvisibilityOfElementLocated(By.XPath("//*[@id='ui-datepicker-div']"));

        //    AddVisitClick.Click();

        //    return new OwnerInformation(Driver);
        //}
    }
}