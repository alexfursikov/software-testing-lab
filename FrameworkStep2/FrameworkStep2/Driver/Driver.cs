using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Driver
{
    public class DriverInstance
    {
        private static IWebDriver _driver;
        private DriverInstance() { }
        public static IWebDriver GetInstance()
        {
            if(_driver == null)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }
        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
