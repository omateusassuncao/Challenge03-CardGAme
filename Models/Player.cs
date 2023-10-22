using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge03.Models
{
    public class Player
    {
        public Player()
        {
        }
        public Player(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter apenas números e ter 11 dígitos.")]
        public string CPF { get; set; }

        public int? BaralhoId { get; set; }
        public Baralho? Baralho { get; set; }

        internal void AddBaralho(Baralho baralho)
        {
            if(BaralhoId != null)
            Baralho = baralho;
            BaralhoId = baralho.Id;
        }
    }
}
