using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.ObjectModel;

namespace TestingPO
{
    public class SearchPage
    {
        IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            try
            {
                this.driver = driver;
                PageFactory.InitElements(driver, this);

            }
            catch (NoSuchElementException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
