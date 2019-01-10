using Framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Steps
{
    public class Steps
    {
        private IWebDriver driver;

        public void InitBrowser()
        {
            driver = WebDriver.WebDriver.GetInstance();
        }

        public void CloseBrowser()
        {
            WebDriver.WebDriver.CloseBrowser();
        }
        
        public string GetRegion()
        {
            RegionPage regionPage = new RegionPage(driver);
            regionPage.goToPage();

            return regionPage.getRegion();
        }

        public bool CheckLanguage(string region)
        {
            bool success = true;

            MainPage mainpage = new MainPage(driver);
            mainpage.goToPage();
            string URL = mainpage.getURLByContry(MainPage.Country.Germany);
            mainpage.goToPage(URL);

            if (mainpage.getPageRegion(region) == null)
                success = false;

            return success;
        }

        public bool ApplyFilersAndCheckResult(string destination)
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.goToPage(destination);

            return searchPage.CheckFields(destination);
        }

        public bool CheckBeachRest()
        {
            TripFinderPage tripFinderPage = new TripFinderPage(driver);
            tripFinderPage.goToPage();
            tripFinderPage.selectRestTypeBeach();

            return tripFinderPage.CheckResultedList();
        }

        public bool CheckResulredList()
        {
            TripFinderPage tripFinderPage = new TripFinderPage(driver);

            return tripFinderPage.CheckFirstfromResultedList();
        }

        public bool OpenHotelPageFromSearchPage()
        {
            bool success = true;

            SearchPage sp = new SearchPage(driver);
            string cityto = driver.FindElement(By.XPath("(//input)[6]")).GetAttribute("value");
            cityto = cityto.Substring(0,cityto.IndexOf(' '));
            IWebElement hotels = driver.FindElement(By.XPath("//li[@class='col js-vertical-hotels _bd _v _CZ _mK']"));
            hotels.Click();

            success = driver.FindElement(By.XPath("//input[1]")).GetAttribute("value").StartsWith(cityto);

            var butontohotelspage = driver.FindElement(By.XPath("(//button)[8]"));
            butontohotelspage.Click();

            return success;
        }

        public bool Open2TabsAndCheckCosts(string city)
        {
            bool success = true;

            MainPage mainpage = new MainPage(driver);
            mainpage.goToPage();
            mainpage.EnterDestinationAndSearch(city);
            WaitForPriceElement();

            string costTocompare = driver.FindElement(By.XPath("//span[@class='price option-text']")).Text;

            //it's not working in firefox
            //var el = driver.FindElement(By.TagName("body"));
            //el.SendKeys(Keys.Control + 'T');
            //driver.SwitchTo().Window(driver.WindowHandles.Last());

            mainpage.goToPage();
            mainpage.EnterDestinationAndSearch(city);
            WaitForPriceElement();
            success = costTocompare.Equals(driver.FindElement(By.XPath("//span[@class='price option-text']")).Text);

            return success;
        }

        private void WaitForPriceElement()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class='price option-text']")));
        }

        public bool ValidateMoreResultsButton(string v)
        {
            bool success = true;

            MainPage mainpage = new MainPage(driver);
            mainpage.goToPage();
            mainpage.EnterDestinationAndSearch(v);

            SearchPage sp = new SearchPage(driver);
            success = sp.ValidateSearchAndMoreButton();

            return success;

        }

        public bool ValidateFieldMainPage(string city)
        {
            MainPage mainpage = new MainPage(driver);
            mainpage.goToPage();
            mainpage.EnterDestinationAndSearch(city);
            SearchPage sp = new SearchPage(driver);

            return sp.CheckErrorMessage();
        }

        public bool TestTwoStarHotels()
        {
            HotelPage hotelpage = new HotelPage(driver);

            return hotelpage.CheckTwoStarHotels();
        }

        public bool goToOZONOrderPage()
        {
            bool success = true;

            SearchPage sp = new SearchPage(driver);
            sp.TryToOrderOnOZON();
            
            return success;
        }

        public bool OrderCar(string city)
        {
            OrderCarPage ocp = new OrderCarPage(driver);

            return ocp.Order(city);
        }
    }
}
