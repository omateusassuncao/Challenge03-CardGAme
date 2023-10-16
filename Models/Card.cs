using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge03.Models
{
    public class Card
    {
        public Card() { }
        public Card(string nome, string historia, string classe, string elemento, string imageUrl, string assinatura)
        {
            Nome = nome;
            Historia = historia;
            Classe = classe;
            Elemento = elemento;
            HP = CalcularHP();
            SP = CalcularSP();
            Forca = CalcularForca();
            Defesa = CalcularDefesa();
            Agilidade = CalcularAgilidade();
            Inteligencia = CalcularInteligencia();
            ImageUrl = imageUrl;
            Assinatura = assinatura;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Historia { get; set; }
        public string ImageUrl { get; set; }
        public string Assinatura { get; set; }
        public int? BaralhoId { get; set; }
        public Baralho? Baralho { get; set; }


        //Propriedades
        public string Classe { get; set; } //Guerreiro, Mago, Arqueiro, Ladrão
        public string Elemento { get; set; } //Fogo, Água, Ar, Terra
        //Calculados
        public int HP { get; set; }
        public int SP { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Agilidade { get; set;}
        public int Inteligencia { get; set;}


        private int CalcularHP()
        {
            switch (this.Classe)
            {
                case "Guerreiro": return 100;
                case "Mago": return 50;
                case "Arqueiro": return 75;
                case "Ladrão": return 75;
                default: return 10;
            }

        }
        private int CalcularSP()
        {
            switch (this.Classe)
            {
                case "Guerreiro": return 50;
                case "Mago": return 100;
                case "Arqueiro": return 75;
                case "Ladrão": return 75;
                default: return 10;
            }

        }
        private int CalcularForca()
        {
            switch (this.Classe)
            {
                case "Guerreiro": return 75;
                case "Mago": return 25;
                case "Arqueiro": return 50;
                case "Ladrão": return 75;
                default: return 10;
            }

        }
        private int CalcularDefesa()
        {
            switch (this.Classe)
            {
                case "Guerreiro": return 100;
                case "Mago": return 75;
                case "Arqueiro": return 50;
                case "Ladrão": return 50;
                default: return 10;
            }

        }
        private int CalcularAgilidade()
        {
            switch (this.Classe)
            {
                case "Guerreiro": return 50;
                case "Mago": return 50;
                case "Arqueiro": return 75;
                case "Ladrão": return 100;
                default: return 10;
            }

        }
        private int CalcularInteligencia()
        {
            switch (this.Classe)
            {
                case "Guerreiro": return 25;
                case "Mago": return 100;
                case "Arqueiro": return 75;
                case "Ladrão": return 25;
                default: return 10;
            }

        }

    }
}
