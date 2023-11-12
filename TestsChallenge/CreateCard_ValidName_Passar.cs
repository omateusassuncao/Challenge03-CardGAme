using Challenge03.Models;
using Microsoft.Data.SqlClient.Server;
using System.Xml.Linq;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class CreateCard_ValidName_Passar
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

        [TestCase("Monstro")]
        [TestCase("Monstro Fortaço")]
        [TestCase("Monstro Fortaço da Montanha")]
        public void CriarCard_ValidName_DoesNotThrow(string value)
        {
            _card.Nome = value;
            TestDelegate result = () => new Card(_card.Nome, _card.Historia, _card.TextoParaImagem, _card.Classe, _card.Elemento, _card.ImageUrl, _card.Assinatura, _card.Baralho);
            Assert.DoesNotThrow(result, "O nome é válido mas não foi aceito");
        }
    }
}