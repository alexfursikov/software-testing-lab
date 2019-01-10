using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tests
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void SetUp()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void CleanUp()
        {
            steps.CloseBrowser();
        }

        [Test] //Test #1
        public void CheckLanguage()
        {
            string region = steps.GetRegion();
            bool success = steps.CheckLanguage(region);

            Assert.AreEqual(success, true);
        }

        [Test] //Test #2
        public void CheckBeachRest()
        {
            bool success = steps.CheckBeachRest();

            Assert.AreEqual(success, true);
        }

        [Test] //Test #3
        public void CheckMainPageFilters()
        {
            bool success = steps.ApplyFilersAndCheckResult("Москва");

            Assert.AreEqual(success, true);
        }

        [Test] //Test #4
        public void TestOrderSite()
        {
            bool success = steps.CheckBeachRest();
            success = steps.CheckResulredList();

            Assert.Equals(success, true);
        }

        [Test] //Test #5
        public void TestHotels()
        {
            bool success = steps.ApplyFilersAndCheckResult("Москва");
            success = steps.OpenHotelPageFromSearchPage();
            success = steps.TestTwoStarHotels();

            Assert.AreEqual(success, true);
        }

        [Test] //Test #6
        public void TestSimulteniousOrdering()
        {

            bool success = this.steps.ApplyFilersAndCheckResult("Москва (MOW)");
            success = this.steps.goToOZONOrderPage();

            Assert.AreEqual(success, true);
        }

        [Test] //Test #7
        public void OrderCar()
        {
            bool success = steps.OrderCar("Москва, Россия - Домодедово");

            Assert.AreEqual(success, true);
        }

        [Test] //Test #8
        public void CheckSimilarCosts()
        {
            bool success = steps.Open2TabsAndCheckCosts("Москва (DME)");

            Assert.AreEqual(success, true);
        }

        [Test] //Test #9
        public void ValidateCityWithoutAirport()
        {
            bool success = steps.ValidateFieldMainPage("Гомель");

            Assert.AreEqual(success, true);
        }

        [Test] //Test #10
        public void CkeckMoreResultsButton()
        {
            bool success = steps.ValidateMoreResultsButton("Москва (DME)");

            Assert.AreEqual(success, true);
        }
    }
}
