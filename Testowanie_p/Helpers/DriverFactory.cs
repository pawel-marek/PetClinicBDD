using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PetClinic.Tests
{
    internal class DriverFactory
    {
        public static IWebDriver ReturnDriver(DriverType driverType)
        {
            IWebDriver driver;
            switch (driverType)
            {
                case DriverType.Chrome:
                    return ChromeOK();
                    break;
                case DriverType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case DriverType.Edge:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException();
            }
            return driver;
        }

        internal enum DriverType
        {
            Chrome,
            Firefox,
            Edge
        }

        private static IWebDriver ChromeOK()
        { 
             ChromeOptions options = new ChromeOptions();
             options.AddArgument("--start-maximized");
             options.AddArgument("disable-infobars");

            IWebDriver driver = new ChromeDriver(options);
             return driver;
        }


    }




}
