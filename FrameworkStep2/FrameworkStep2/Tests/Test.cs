using NUnit.Framework;
using System.Threading;

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
            Assert.AreEqual("Поле не заполнено", steps.GetBadDestinationError());
        }

        [Test]
        public void FindOriginationEqualsDestinationRoute()
        {
            steps.FindRoute("MOW", "MOW");
            Assert.AreEqual("Поле не заполнено", steps.GetBadOriginationError());
        }

        [Test]
        public void FindRouteWithoutDate()
        {
            steps.FindRouteWithoutDate("MOW", "MSQ");
            Assert.AreEqual("Выберите дату вылета туда и обратно", steps.GetDateError());
        }

        [Test]
        public void FindRouteWithoutReturnDate()
        {
            steps.FindRouteWithoutReturnDate("MOW", "MSQ");
            Assert.AreEqual("Выберите дату обратного вылета", steps.GetDateError());
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
            Thread.Sleep(1000);
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
            Assert.AreEqual("Пора\r\nкататься", steps.GetSecondPromoText());
        }

        [Test]
        public void SwitchToThirdAd()
        {
            steps.SwitchToThirdAd();
            Assert.AreEqual("Начинать\r\nпутешествие\r\nс покупок", steps.GetThirdPromoText());
        }
    }
}