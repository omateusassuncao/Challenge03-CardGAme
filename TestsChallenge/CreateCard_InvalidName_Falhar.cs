using Challenge03.Models;
using Microsoft.Data.SqlClient.Server;
using System.Xml.Linq;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class CreateCard_InvalidName_Falhar
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

        [TestCase("")]
        [TestCase("    ")]
        [TestCase("3412343412")]
        [TestCase("%$#@ D%S$DS %$@ S%#@% ")]
        public void CriarCard_InvalidName_CatchException(string value)
        {
            _card.Nome = value;
            TestDelegate result = () => new Card(_card.Nome, _card.Historia, _card.TextoParaImagem, _card.Classe, _card.Elemento, _card.ImageUrl, _card.Assinatura, _card.Baralho);
            Assert.Catch<Exception>(result, "O nome não pode ser nulo ou conter números ou caractéres especiais");
        }
    }
}