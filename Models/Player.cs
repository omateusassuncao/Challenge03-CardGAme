using System.ComponentModel.DataAnnotations;

namespace Challenge03.Models
{
    public class Player
    {
        public Player(string nome)
        {
            Nome = nome;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Card> Baralho { get; set; }

        //public void AdicionarCard(Card card)
        //{
        //    Baralho.Add(card);
        //}
        //public void RemoverCard(Card card)
        //{
        //    Baralho.Remove(card);
        //}
    }
}
