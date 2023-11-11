using Challenge03.Models;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class CreateCard_InvalidName_Falhar
    {
        private Card _card;

        [SetUp]
        public void SetUp()
        {
            _card = new Card();
        }

        [TestCase("")]
        [TestCase("    ")]
        [TestCase("3412343412")]
        public void CriarCard_InvalidName_ReturnFalse(string value)
        {
            var result = _card.validaNome(value);

            Assert.IsFalse(result, "1 should not be null");
        }
    }
}