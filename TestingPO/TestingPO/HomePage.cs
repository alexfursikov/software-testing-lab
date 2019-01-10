using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestingPO
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            try
            {
                this._driver = driver;
                PageFactory.InitElements(_driver, this);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [FindsBy(How = How.ClassName, Using = "btn-clean")]
        private IWebElement _clear;
        

        [FindsBy(How = How.Id, Using = "flights_origin2")]
        private IWebElement _origin;

        [FindsBy(How = How.Id, Using = "flights_destination2")]
        private IWebElement _destination;

        [FindsBy(How = How.Id, Using = "date-opener2")]
        private IWebElement _datePicker;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datepicker2\"]/div/table/tbody/tr[3]/td[3]")]
        private IWebElement _depStrDate;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datepicker2\"]/div/table/tbody/tr[3]/td[5]")]
        private IWebElement _retStrDate;

        [FindsBy(How = How.Id, Using = "search-btn-expand-bot")]
        private IWebElement _searchBtn;


        public SearchPage GoToSearch()
        {
            _clear.Click();
            _origin.SendKeys("Москва");
            _destination.Clear();
            _destination.SendKeys("Рим");
            _datePicker.Click();
            _depStrDate.Click();
            _retStrDate.Click();
            _searchBtn.Click();

            return new SearchPage(_driver);
        }
    }
}
