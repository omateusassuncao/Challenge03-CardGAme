using Challenge03.Models;
using Microsoft.Data.SqlClient.Server;
using System.Xml.Linq;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class CreatePlayer_ValidName_Passar
    {
        private Player _player;
        private Baralho _baralho;
        private Card _card;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("PLayer", "12345678900");
            _baralho = new Baralho(_player);
            _card = new Card("Monstro Teste", "Era uma vez...", "Um grande sol", "Guerreiro", "Fogo", "www.google.com", "Player", _baralho);
        }

        [TestCase("Mateus")]
        [TestCase("Mateus Vieira")]
        [TestCase("Mateus Vieira da Assunção")]
        public void CreatePlayer_ValidName_DoesNotThrow(string value)
        {
            _player.Nome = value;
            TestDelegate result = () => new Player(_player.Nome, _player.CPF);
            Assert.DoesNotThrow(result, "O nome é válido mas não foi aceito");
        }
    }
}