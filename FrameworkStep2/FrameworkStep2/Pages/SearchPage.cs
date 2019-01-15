using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    public class SearchPage
    {
        private const string BASE_URL = "https://www.s7-airlines.com/ru/";

        private readonly WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "flights_origin2")]
        private IWebElement cityFrom;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[3]/div[2]/div/div/div/div/div[1]/div/div/div[1]/div[1]/form/div[2]/div[1]/div/span[1]")]
        private IWebElement selectedCityFrom;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[3]/div[2]/div/div/div/div/div[1]/div/div/div[1]/div[1]/form/div[2]/div[3]/div/span[1]")]
        private IWebElement selectedCityTo;

        [FindsBy(How = How.Id, Using = "flights_origin2-error")]
        private IWebElement cityFromError;

        [FindsBy(How = How.Id, Using = "flights_destination2")]
        private IWebElement cityTo;

        [FindsBy(How = How.Id, Using = "flights_destination2-error")]
        private IWebElement cityToError;

        [FindsBy(How = How.Id, Using = "date-opener2")]
        private IWebElement datePicker;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/header/div[3]/div/ul/li[6]/a")]
        private IWebElement langPicker;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"flights_one_way_bot2\"]")]
        private IWebElement oneWayTrip;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/header/div[3]/div/ul/li[6]/form/div/div[2]/div/a[1]/div")]
        private IWebElement russianLang;

        [FindsBy(How = How.Id, Using = "search-btn-expand-bot")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.Id, Using = "slick-slide-control01")]
        private IWebElement secondAdButton;

        [FindsBy(How = How.Id, Using = "slick-slide-control02")]
        private IWebElement thirdAdButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[3]/div[1]/div/div/div[2]/div/div/div/a/h3")]
        private IWebElement secondPromo;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[3]/div[1]/div/div/div[3]/div/div/div/a/h3")]
        private IWebElement thirdPromo;


        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void SearchClick()
        {
            buttonSearch.Click();
        }

        public void FillAirports(string from, string to)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(from);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(Keys.ArrowDown);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(Keys.Enter);

            wait.Until(ExpectedConditions.ElementToBeClickable(cityTo));
            cityTo.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(cityTo));
            cityTo.SendKeys("");
            cityTo.SendKeys(to);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityTo));
            cityTo.SendKeys(Keys.Enter);
        }

        public void SetOneWayRoute()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(datePicker));
            ExpectedConditions.ElementIsVisible(By.Id("flights_return_way_bot2"));
            datePicker.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", oneWayTrip);
        }

        public void SelectDateTomorrow(int directions)
        {
            for (int i = 0; i < directions; i++)
            {
                datePicker.Click();
                IWebElement today = driver.FindElement(By.CssSelector("#datepicker2 > div:nth-child(1) > table:nth-child(2) > tbody:nth-child(2) > tr:nth-child(2) > td:nth-child(5) > a:nth-child(1)"));
                //wait.Until(ExpectedConditions.ElementToBeClickable(today));
                today.Click();
            }
        }

        public void SetRussian()
        {
            langPicker.Click();
            russianLang.Click();
        }

        public void GoToSecondAd()
        {
            secondAdButton.Click();
        }

        public void GoToThirdAd()
        {
            thirdAdButton.Click();
        }


        public string GetBadDestinationError()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("flights_destination2-error")));
            return cityToError.Text;
        }

        public string GetBadOriginationError()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("flights_origin2-error")));
            return cityFromError.Text;
        }

        public string GetDateError()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"aviaBot\"]/div[2]/div[4]/div[1]")));
            IWebElement dateError = driver.FindElement(By.XPath("//*[@id=\"aviaBot\"]/div[2]/div[4]/div[1]"));

            return dateError.Text;
        }

        public string GetOriginationFieldValue()
        {
            return selectedCityFrom.Text;
        }

        public string GetDestinationFieldValue()
        {
            return selectedCityTo.Text;
        }

        public string GetSearchButtonText()
        {
            return buttonSearch.Text;
        }

        public string GetSecondPromoText()
        {
            return secondPromo.Text;
        }

        public string GetThirdPromoText()
        {
            return thirdPromo.Text;
        }

    }
}
