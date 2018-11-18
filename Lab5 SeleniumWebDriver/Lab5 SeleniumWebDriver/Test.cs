using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Lab5_SeleniumWebDriver
{
    class Test
    {
        IWebDriver driver;

        public void SearchWithValidData()
        {
            try
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.s7-airlines.com/ru/");
                IWebElement destinationInput = driver.FindElement(By.Id("flights_destination2"));
                destinationInput.SendKeys("TestString" + Keys.Enter);
                Thread.Sleep(1000);
                IWebElement searchForm = driver.FindElement(By.Id("search-btn-expand-bot "));
                searchForm.Submit();
                Thread.Sleep(5000);

            }
            catch (Exception e)
            {
                driver.Close();
                Console.WriteLine(e.Message);
            }
        }
    }
}
