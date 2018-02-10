using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using PetClinic.Helpers;
using log4net;
using PetClinic.Tests;

namespace PetClinic.POM_Sites
{
    public class Home : BaseClass
    {
        //private IWebDriver driver;

        private static readonly string Url = "http://localhost:8080/petclinic";

        public Home(IWebDriver driver) : base(driver/*, Url*/)
        {
            //this.Driver = WebBrowser.Current;
            this.Driver = driver;
        }

        public void Navigate()
        {
            //Navigate to the site
            //WebBrowser.Current.Navigate().GoToUrl(Url);
            Driver.Navigate().GoToUrl(Url);

        }

        //--------------------------------------

        public IWebElement WelcomeText => Driver.FindElement(By.XPath("/html/body/div/h2"));

        //public string CheckText()
        //{
        //    var drivwwer = driver.FindElement(By.XPath("/html/body/div/h2"));
        //    var ttt = WelcomeText.Text;
        //     //public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        //    return ttt;
        //}


        public IWebElement PictureOnHomePage => Driver.FindElement(By.XPath("/html/body/div/img[2]"));

        public bool CheckPicture()
        {
            Boolean ImagePresent =
                (Boolean) ((IJavaScriptExecutor)Driver).ExecuteScript(
                    "return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0",
                    PictureOnHomePage);

            return ImagePresent;
        }

        //[FindsBy(How = How.XPath, Using = "/html/body/div/div/div/ul/li")]
        //public IList<IWebElement> MenuItems { get; private set; }

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





