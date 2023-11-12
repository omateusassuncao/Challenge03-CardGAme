using Challenge03.Models;
using Microsoft.Data.SqlClient.Server;
using System.Xml.Linq;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class CreatePlayer_ValidCPF_Passar
    {
        private Player _player;
        private Baralho _baralho;
        private Card _card;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("PLayer", "12332112345");
            _baralho = new Baralho(_player);
            _card = new Card("Monstro Teste", "Era uma vez...", "Um grande sol", "Guerreiro", "Fogo", "www.google.com", "Player", _baralho);
        }

        [TestCase("12345678910")]
        [TestCase("99999999999")]
        public void CriarPlayer_ValidCPF_DoesNotThrow(string value)
        {
            _player.CPF = value;
            TestDelegate result = () => new Player(_player.Nome, _player.CPF);
            Assert.DoesNotThrow(result, "O CPF é válido mas não foi aceito");
        }
    }
}