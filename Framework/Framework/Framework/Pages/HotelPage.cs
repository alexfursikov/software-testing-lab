using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class HotelPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "(//div[@class='star-label'])[2]")]
        private IWebElement twoandmoreStars;

        public HotelPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public bool CheckTwoStarHotels()
        {
            bool success = true;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='star-label'])[2]")));
            twoandmoreStars.Click();

            int stars = Convert.ToInt16(driver.FindElement(By.XPath("//div[@class=' col col-stars']/div")).GetAttribute("data-count"));
            if (stars < 2)
                success = false;

            return success;
        }
    }
}
