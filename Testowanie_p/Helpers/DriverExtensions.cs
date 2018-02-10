using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PetClinic.Tests
{
    public class DriverExtensions
    {
        //public static ChromeOptions StartChromeOptions()
        //{
        //    var options = new ChromeOptions();
        //    options.AddArgument("--start-maximized");
        //    options.AddArgument("disable-infobars");

        //    return options;
        //}

        public static void TakeScreenshotOnFailure(IWebDriver driver)
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
                screen.SaveAsFile(CreateFileName(), ScreenshotImageFormat.Jpeg);
                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }
        }

        public static string CreateFileName()
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            string fileName = "D://Screens//" + TestContext.CurrentContext.Test.Name + "-" + timeStamp + ".jpeg";
            return fileName;
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }

}
