using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.WebDriver
{
    public class WebDriver
    {
        private static IWebDriver driver;

        private WebDriver() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            }

            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Close();
            driver = null;
        }
    }
}
