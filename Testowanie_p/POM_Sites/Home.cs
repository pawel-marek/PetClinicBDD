using OpenQA.Selenium;
using PetClinic.Helpers;
using System;
using System.Collections.Generic;

namespace PetClinic.POM_Sites
{
    public class Home : BaseClass
    {
        private static readonly string Url = "http://localhost:8080/petclinic";

        public Home(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
        }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public IWebElement WelcomeText => Driver.FindElement(By.XPath("/html/body/div/h2"));

        public IWebElement PictureOnHomePage => Driver.FindElement(By.XPath("/html/body/div/img[2]"));

        public bool CheckPicture()
        {
            Boolean ImagePresent =
                (Boolean) ((IJavaScriptExecutor)Driver).ExecuteScript(
                    "return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0",
                    PictureOnHomePage);

            return ImagePresent;
        }

        public IList<IWebElement> MenuItems => Driver.FindElements(By.XPath("/html/body/div/div/div/ul/li"));

        public List<string> CheckMenuItems()
        {
            var targetText = new List<string>();
            foreach (var VARIABLE in MenuItems)
            {
                string ele = VARIABLE.Text;
                targetText.Add(ele);
            }

            return targetText;
        }

        public IWebElement OwnerButton => Driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[2]/a"));

        public FindOwners ClickFindOwners()
        {
            ClickOnElement(OwnerButton);

            return new FindOwners(Driver);
        }

        public List<string> ExpectedMenuItems()
        {
            XmListStructure resultDataStructure = new XmListStructure();
            var targetItemsList = resultDataStructure.ParseXml("/Items/ExpectedMenuItems/Value");

            return targetItemsList;
        }
    }
}





