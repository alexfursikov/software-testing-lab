using OpenQA.Selenium;
using Framework.Pages;

namespace Framework.Steps
{
    public class Steps
    {
        IWebDriver driver;
        MainPage mainPage;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
            mainPage = new MainPage(driver);
            mainPage.OpenPage();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void FindRoute(string from, string to)
        {
            if (from != "")
            {
                mainPage.Origin(from);
            }
            if (to != "")
            {
                mainPage.Destination(to);

            }
            mainPage.SelectDateTomorrow(2);
            mainPage.SearchClick();
        }

        public void FindRouteWithoutDate(string from, string to)
        {
            mainPage.Origin(from);
            mainPage.Destination(to);
            mainPage.SearchClick();
        }

        public void FindRouteWithoutReturnDate(string from, string to)
        {
            mainPage.Origin(from);
            mainPage.Destination(to);
            mainPage.SelectDateTomorrow(1);
            mainPage.SearchClick();
        }

        public void FillAirports(string from, string to)
        {
            if (from != "")
            {
                mainPage.Origin(from);
            }
            if (to != "")
            {
                mainPage.Destination(to);
            }
        }

        public void CheckFromFieldAutoComplete(string from, string to)
        {
            mainPage.Origin(from);
            mainPage.Destination(to);
        }

        public void ChangeLocaleToRussian()
        {
            mainPage.SetRussian();
        }

        public void SwitchToSecondAd()
        {
            mainPage.GoToSecondAd();
        }

        public void SwitchToThirdAd()
        {
            mainPage.GoToThirdAd();
        }

        public string GetBadDestinationError()
        {
            return mainPage.GetBadDestinationError();
        }

        public string GetOriginationFieldValue()
        {
            return mainPage.GetOriginationFieldValue();
        }

        public string GetDestinationFieldValue()
        {
            return mainPage.GetDestinationFieldValue();
        }

        public string GetBadOriginationError()
        {
            return mainPage.GetBadOriginationError();
        }

        public string GetSearchButtonText()
        {
            return mainPage.GetSearchButtonText();
        }

        public string GetDateError()
        {
            return mainPage.GetDateError();
        }

        public string GetSecondPromoText()
        {
            return mainPage.GetSecondPromoText();
        }

        public string GetThirdPromoText()
        {
            return mainPage.GetThirdPromoText();
        }
    }
}