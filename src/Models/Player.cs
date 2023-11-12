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
            Nome = validaNome(nome);
            CPF = validaCPF(cpf);
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "O campo deve conter apenas letras e espaços.")]
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

        //Unit Tests

        public string validaNome(string nome)
        {
            if (nome == "" || nome.Trim() == "")
            {
                throw new Exception("Nome nulo");
            }
            else if (nome.Any(char.IsDigit))
            {
                throw new Exception("Nome contêm números");
            }
            else if (nome.Any(char.IsPunctuation) || nome.Any(char.IsSymbol))
            {
                throw new Exception("Nome contêm caractéres espeiais");
            }
            return nome;
        }

        public string validaCPF(string cpf)
        {
            if (cpf == "" || cpf.Trim() == "")
            {
                throw new Exception("CPF nulo");
            }
            else if (cpf.Any(char.IsLetter) || cpf.Any(char.IsPunctuation) || cpf.Any(char.IsSymbol) || cpf.Any(char.IsWhiteSpace))
            {
                throw new Exception("Nome contêm letras ou caractéres espeiais");
            }
            else if (cpf.Length != 11)
            {
                throw new Exception("CPF não contém 11 dígitos");
            }
            return cpf;
        }
    }
}
