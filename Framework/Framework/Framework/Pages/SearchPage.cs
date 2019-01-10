using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    public class SearchPage
    {
        private IWebDriver driver;

        private string ERROR_MESSAGE = "Увы, нам не удалось найти подходящие рейсы.";
        private string SEARCH_ENDED = "Поиск завершен";
        private string departdate;

        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Место назначения']")]
        private IWebElement destinationelement;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage(string destination)
        {
            MainPage main = new MainPage(driver);
            main.goToPage();
            main.fillFilters(destination);

            IWebElement departelement = driver.FindElement(By.XPath("//div[@aria-label='Дата вылета']"));
            departelement.Click();
            departdate = departelement.Text;

            main.SubmitSearch();
        }

        public bool CheckFields(string destination)
        {
            bool success = true;
            
            var city = destinationelement.GetAttribute("value").StartsWith(destination);
            if (city == false)
                success = false;

            success = CheckCount();
            
            IWebElement newdepartdate = driver.FindElement(By.XPath("//div[@aria-label='Дата вылета']"));
            newdepartdate.Click();

            if (!departdate.Equals(newdepartdate.Text))
                success = false;

            IWebElement moreButton = driver.FindElement(By.XPath("//a[@class='moreButton']"));
            if (moreButton == null)
                success = false;

            return success;
        }

        private bool CheckCount()
        {
            bool success = true;
            string countstring = driver.FindElement(By.ClassName("count")).Text;
            countstring = new String(countstring.Where(Char.IsDigit).ToArray());

            if (countstring != String.Empty)
            {
                int count = Convert.ToInt16(countstring);

                if (count < 0)
                    success = false;
            }

            return success;
        }

        public void TryToOrderOnOZON()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-more='ещё']")));

            //Thread.Sleep(10000);
            driver.FindElement(By.XPath("//a[@data-more='ещё']")).Click();

            Actions action = new Actions(driver);
            action.SendKeys(Keys.PageDown);
            action.Perform();

            var ordersystems = driver.FindElements(By.XPath("//button"));
            var hiddenbutton = ordersystems.Where(g => g.GetAttribute("id").EndsWith("-OZON-only")).Select(g => g).First();

            action = new Actions(driver);
            action.MoveToElement(hiddenbutton);
            action.Perform();

            Thread.Sleep(2000);
            hiddenbutton.Click();

            string url = driver.FindElement(By.XPath("//div[@class='col col-best slim-ticket']/div/div/a")).GetAttribute("href");

            driver.Navigate().GoToUrl(url);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='submit']/button")));
            IWebElement submitbutton = driver.FindElement(By.XPath("//div[@id='submit']/button"));
            //i cannot order real ticket,so sanmle
            //submitbutton.Click();

            action.SendKeys(Keys.Control + "+ t");
            driver.Navigate().GoToUrl(url);
            //submitbutton.Click();
        }

        public bool CheckErrorMessage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath("//div[@class='Common-Results-NoResults hidden']/div")).Text != String.Empty);

            string errortext = driver.FindElement(By.XPath("//div[@class='Common-Results-NoResults hidden']/div")).Text;

            return ERROR_MESSAGE.Equals(errortext);
        }

        public void ChooseFirstAuto()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            Thread.Sleep(7000);
            var buttons = driver.FindElements(By.TagName("button"));

            IWebElement hiddenbutton = buttons.Where(g => g.GetAttribute("id").EndsWith("-avis-only")).Select(g => g).First();

            Actions action = new Actions(driver);
            ScrollBy(600);

            action.MoveToElement(hiddenbutton);
            action.Perform();

            hiddenbutton.Click();
            ScrollBy(-600);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='_bd _xY _a _ej _lA _kE _ht _kG _x3 _x6 _mK _x7 _yf']")));
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//button[@class='_bd _xY _a _ej _lA _kE _ht _kG _x3 _x6 _mK _x7 _yf']")).Click();
        }


        public bool ValidateSearchAndMoreButton()
        {
            bool success = true;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath("//div[@class='Base-Results-Rail Flights-Results-FlightLeftRail']/div/div/div[@class='title']")).Text != SEARCH_ENDED);

            success = CheckCount();

            var a = wait.Until(driver => ExpectedConditions.ElementExists(By.XPath("//div[@class='Common-Results-Paginator ButtonPaginator visible']")));
            success = a != null ? true : false; 

            return success;
        }

        private void ScrollBy(int by)
        {
            IJavaScriptExecutor exe = driver as IJavaScriptExecutor;
            var js = String.Format("window.scrollBy(0, {0});", by);
            exe.ExecuteScript(js);
        }

    }
}
