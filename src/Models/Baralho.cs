using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge03.Models
{
    public class Baralho
    {
        public Baralho()
        {
        }
        public Baralho(Player player)
        {
            Name = player.Nome + "'s Deck";
            Player = player;
            PlayerId = player.Id;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Card>? Cards { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
