using Challenge03.Models;
using Microsoft.Data.SqlClient.Server;
using System.Xml.Linq;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class CreatePlayer_InvalidName_Falhar
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

        [TestCase("")]
        [TestCase("    ")]
        [TestCase("3412343412")]
        [TestCase("%$#@ D%S$DS %$@ S%#@% ")]
        public void CriarPlayer_InvalidName_CatchException(string value)
        {
            _player.Nome = value;
            TestDelegate result = () => new Player(_player.Nome, _player.CPF);
            Assert.Catch<Exception>(result, "O nome não pode ser nulo ou conter números ou caractéres especiais");
        }
    }
}