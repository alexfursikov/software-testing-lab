using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class RegionPage
    {
        private const string BASE_URL = "https://www.iplocation.net/";
        private IWebDriver driver;

        public RegionPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//table[1]//tbody/tr[1]/td[4]")]
        private IWebElement regionElement;

        public void goToPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string getRegion()
        {
            return regionElement.Text;
        }
    }
}
