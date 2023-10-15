using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Challenge03.Models
{
    public class Batalha
    {
        // Construtor sem parâmetros necessário para o Entity Framework
        public Batalha()
        {
        }

        public Batalha(Player playerA, Card cardA, string escolhaA, Player playerB, Card cardB, string escolhaB)
        {
            Player_A = playerA;
            Card_A = cardA;
            Escolha_A = escolhaA;
            Player_B = playerB;
            Card_B = cardB;
            Escolha_B = escolhaB;
            Resultado = Batalhar();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Player Player_A { get; set; }
        public Card Card_A { get; set; }
        public string Escolha_A { get; set; }
        public Player Player_B { get; set; }
        public Card Card_B { get; set; }
        public string Escolha_B { get; set; }
        public string Resultado { get; }
        public Player? Vencedor { get; set; }
        public string LogBatalha { get; set; }

        private string Batalhar()
        {
            string round_1_start = "Player " + Player_A + " escolheu " + Escolha_A;
            EscreverLog(round_1_start);

            Card? vencedorRound1 = RoundCalculadora(Escolha_A, Card_A, Card_B);
            string round_1_resultado = "";
            if (vencedorRound1 == null) round_1_resultado = "Resultado do round 1: Empate";
            else round_1_resultado = "Resultado do round 1: " + vencedorRound1.Nome + "(" + vencedorRound1.Baralho.Player.Nome + ")";
            EscreverLog(round_1_resultado);

            Card? vencedorRound2 = RoundCalculadora(Escolha_B, Card_B, Card_A);
            string round_2_resultado = "";
            if (vencedorRound2 == null) round_2_resultado = "Resultado do round 2: Empate";
            else round_2_resultado = "Resultado do round 2: " + vencedorRound2.Nome + "(" + vencedorRound2.Baralho.Player.Nome + ")";
            EscreverLog(round_2_resultado);

            if (vencedorRound1 == vencedorRound2)
            {
                Vencedor = vencedorRound1.Baralho.Player;
                string resultado_final = "O vencedor da batalha é: " + vencedorRound1.Nome + "(" + vencedorRound1.Baralho.Player.Nome + ")";
                EscreverLog(resultado_final);
                return resultado_final;
            }
            else
            {
                Vencedor = null;
                string resultado_final = "A batalha empatou!";
                EscreverLog(resultado_final);
                return resultado_final;
            }
        }

        private Card? RoundCalculadora(string escolha, Card card_1, Card card_2)
        {
            switch (escolha)
            {
                case "Forca": { if (card_1.Forca == card_2.Forca) return null; else if (card_1.Forca > card_2.Forca) return card_1; else return card_2; };
                case "Defesa": { if (card_1.Defesa == card_2.Defesa) return null; else if (card_1.Defesa > card_2.Defesa) return card_1; else return card_2; };
                case "Agilidade": { if (card_1.Agilidade == card_2.Agilidade) return null; else if (card_1.Agilidade > card_2.Agilidade) return card_1; else return card_2; };
                case "Inteligência": { if (card_1.Inteligencia == card_2.Inteligencia) return null; else if (card_1.Inteligencia > card_2.Inteligencia) return card_1; else return card_2; };
                default: return null;
            }
        }

        private void EscreverLog(string log)
        {
            LogBatalha = LogBatalha + "; " + log;
        }

    }
}
