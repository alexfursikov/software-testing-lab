using NUnit.Framework;

namespace Framework.Tests
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void FindEmptyDestinationRoute()
        {
            steps.FindRoute("MOW", "");
            Assert.AreEqual("Empty field", steps.GetBadDestinationError());
        }

        [Test]
        public void FindOriginationEqualsDestinationRoute()
        {
            steps.FindRoute("MOW", "MOW");
            Assert.AreEqual("Empty field", steps.GetBadOriginationError());
        }

        [Test]
        public void FindRouteWithoutDate()
        {
            steps.FindRouteWithoutDate("MOW", "MSQ");
            Assert.AreEqual("Select departure and return dates", steps.GetDateError());
        }

        [Test]
        public void FindRouteWithoutReturnDate()
        {
            steps.FindRouteWithoutReturnDate("MOW", "MSQ");
            Assert.AreEqual("Select flight date", steps.GetDateError());
        }

        [Test]
        public void CheckOriginationFieldAutoComplete()
        {
            steps.FillAirports("MOW", "");
            Assert.AreEqual("MOW", steps.GetOriginationFieldValue());
        }

        [Test]
        public void CheckDestinationFieldAutoComplete()
        {
            steps.FillAirports("", "MOW");
            Assert.AreEqual("MOW", steps.GetDestinationFieldValue());
        }

        [Test]
        public void CheckRussianLocale()
        {
            steps.ChangeLocaleToRussian();
            Assert.AreEqual("Search", steps.GetSearchButtonText());
        }

        [Test]
        public void SwitchToSecondAd()
        {
            steps.SwitchToSecondAd();
            Assert.AreEqual("Collect\r\nimpressions", steps.GetSecondPromoText());
        }

        [Test]
        public void SwitchToThirdAd()
        {
            steps.SwitchToThirdAd();
            Assert.AreEqual("Fly easily", steps.GetThirdPromoText());
        }
    }
}