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
    public class OrderCarPage
    {
        private IWebDriver driver;
        private string PAGE_URL = "https://www.momondo.ru/prokat-avto/";

        [FindsBy(How = How.XPath, Using = "//div[@class='col col-field col-2-4-l col-pickup-location']/input")]
        private IWebElement citybox;

        [FindsBy(How = How.XPath, Using = "//div[@class='buttonBlock']/button")]
        private IWebElement searchbtn;

        public OrderCarPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
        }

        public bool Order(string city)
        {
            bool success = true;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            this.goToPage();
            citybox.SendKeys(city);
            citybox.SendKeys(Keys.Enter);
            Thread.Sleep(500);

            searchbtn.Click();

            SearchPage sp = new SearchPage(driver);
            sp.ChooseFirstAuto();

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ct-vehicle-block-terms-and-conditions[1]")));

                driver.FindElement(By.XPath("//button[@title='Важная информация']")).Click();
            }
            catch 
            {
                success = false;
            }

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
