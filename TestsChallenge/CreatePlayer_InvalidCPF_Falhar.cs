using Challenge03.Models;
using Microsoft.Data.SqlClient.Server;
using System.Xml.Linq;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class CreatePlayer_InvalidCPF_Falhar
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
        [TestCase("%$#@ D%S$DS %$@ S%#@% ")]
        [TestCase("asdasdasdsd")]
        [TestCase("asd#$%ASD#G")]
        [TestCase("123456789000")]
        [TestCase("1234567890")]
        public void CriarPlayer_InvalidCPF_CatchException(string value)
        {
            _player.CPF = value;
            TestDelegate result = () => new Player(_player.Nome, _player.CPF);
            Assert.Catch<Exception>(result, "O nome não pode ser nulo ou conter números ou caractéres especiais");
        }
    }
}