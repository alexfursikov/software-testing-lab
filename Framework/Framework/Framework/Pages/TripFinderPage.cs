using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class TripFinderPage
    {
        private IWebDriver driver;
        private const string PAGE_URL = "https://www.momondo.by/trip-finder/";

        [FindsBy(How = How.XPath, Using = "//div[@data-option-id='2']")]
        private IWebElement beachelement;

        private List<IWebElement> searchresult;

        public TripFinderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
        }

        public void selectRestTypeBeach()
        {
            beachelement.Click();
        }

        public bool CheckResultedList()
        {
            bool success = true;
            Thread.Sleep(2000);
            var searchresult = driver.FindElements(By.XPath("//span[@class='city'][1]"));
            if (searchresult.Equals("Минск"))
                success = false;

            return success;
        }

        public bool CheckFirstfromResultedList()
        {
            bool success = true;

            IWebElement url = driver.FindElement(By.XPath("//div[@id='resultlist']/div/div/div/a"));
            string cityto = driver.FindElement(By.XPath("//span[@class='city']")).Text;
            driver.Navigate().GoToUrl(url.GetAttribute("href"));

            string newcityto = driver.FindElement(By.XPath("//div[@id='ExplorerEditorial']/div/div/h2/em")).Text;
            if (!newcityto.StartsWith(cityto))
                success = false;

            return success;
        }
    }
}
