using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestingPO
{
    class Program
    {
        private const string _url = "https://www.s7-airlines.com/ru/";
        private WebDriverWait _wait;

        [Test]
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver()
            {
                Url = _url
            };
            HomePage homePage = new HomePage(driver);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            SearchPage searchPage = homePage.GoToSearch();

            driver.Quit();
        }
    }
}
