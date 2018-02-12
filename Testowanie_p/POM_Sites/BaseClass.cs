using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using PetClinic.Helpers;

namespace PetClinic.POM_Sites
{
    public abstract class BaseClass
    {
        private const double Wait = 8;

        public IWebDriver Driver { get; set; }

        protected BaseClass(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void ClickOnElement(IWebElement element)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(Wait))
                .Until(ExpectedConditions.ElementToBeClickable(element))
                .Click();
        }

        public void SendText(IWebElement element, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var el = new WebDriverWait(Driver, TimeSpan.FromSeconds(Wait))
                    .Until(ExpectedConditions.ElementToBeClickable(element));

                new Actions(Driver)
                    .MoveToElement(el)
                    .Click().SendKeys(text)
                    .Build()
                    .Perform();
            }
        }

        public void WaitForUrl(string expectedUrl)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(Wait))
                .Until(Drv => Drv.Url.Equals((expectedUrl)));
        }

        public void WaitForPageTitle(string titleContains)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(Wait))
              .Until(ExpectedConditions.TitleContains(titleContains));
        }


        public void GetClassAttribute(IWebElement element, string attribute, string atributeValue)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(Wait)).
                Until(time => element.GetAttribute(attribute) == atributeValue);
        }

        public void InvisibilityOfElementLocated(By by)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(Wait))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

    




    }
}
