using Microsoft.AspNetCore.Mvc.Rendering;
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
            Player_AId = playerA.Id;
            Card_A = cardA;
            Card_AId = cardA.Id;
            Escolha_A = escolhaA;
            Player_B = playerB;
            Player_BId = playerB.Id;
            Card_B = cardB;
            Card_BId = cardB.Id;
            Escolha_B = escolhaB;
            Resultado = Batalhar();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Player? Player_A { get; set; }
        public int? Player_AId { get; set; }
        public Card? Card_A { get; set; }
        public int? Card_AId { get; set; }
        public string Escolha_A { get; set; }
        public Player? Player_B { get; set; }
        public int? Player_BId { get; set; }
        public Card? Card_B { get; set; }
        public int? Card_BId { get; set; }
        public string Escolha_B { get; set; }
        public string? Resultado { get; }
        public Card? Vencedor { get; set; }
        public int? VencedorId { get; set; }
        public string? LogBatalha { get; set; }

        private string Batalhar()
        {
            string round_1_start = "Player " + Player_A.Nome + " escolheu " + Escolha_A + "\n";
            EscreverLog(round_1_start);

            Card? vencedorRound1 = RoundCalculadora(Escolha_A, Card_A, Card_B);
            string round_1_resultado = "";
            if (vencedorRound1 == null) { round_1_resultado = "Resultado do round 1: Empate"; }
            else { round_1_resultado = "Vencedor do round 1: " + vencedorRound1.Nome + "\n"; }
            EscreverLog(round_1_resultado);

            string round_2_start = "Player " + Player_B.Nome + " escolheu " + Escolha_B + "\n";
            EscreverLog(round_2_start);

            Card? vencedorRound2 = RoundCalculadora(Escolha_B, Card_B, Card_A);
            string round_2_resultado = "";
            if (vencedorRound2 == null) round_2_resultado = "Resultado do round 2: Empate" + "\n";
            else round_2_resultado = "Vencedor do round 2: " + vencedorRound2.Nome + "\n";
            EscreverLog(round_2_resultado);

            if (vencedorRound1 == vencedorRound2)
            {
                Vencedor = vencedorRound1;
                VencedorId = vencedorRound1.Id;
                string resultado_final = "O vencedor da batalha é: " + vencedorRound1.Nome + "\n";
                EscreverLog(resultado_final);
                return resultado_final;

            }

            string round_3_resultado = "";
            int rounds = 2;

            while (Vencedor == null && rounds<10)
            {
                rounds++;
                int randomNumber = (new Random()).Next(1, 4);
                switch (randomNumber)
                {
                    case 1:
                        Escolha_A = "Água"; break;
                    case 2:
                        Escolha_A = "Fogo"; break;
                    case 3:
                        Escolha_A = "Ar"; break;
                    case 4:
                        Escolha_A = "Terra"; break;
                };

                string round_3_start = "Escolha do desempate: " + Escolha_A + "\n";
                EscreverLog(round_3_start);

                Card? vencedorRound3 = RoundCalculadora(Escolha_A, Card_A, Card_B);
                if (vencedorRound3 != null)
                {
                    round_3_resultado = "Vencedor do round: " + vencedorRound3.Nome + "\n";
                    Vencedor = vencedorRound3;
                    VencedorId = vencedorRound3.Id;
                    EscreverLog(round_3_resultado);
                    return round_3_resultado;
                }
                else
                {
                    round_3_resultado = "Round " + rounds + " empatado!";
                    EscreverLog(round_3_resultado);
                }

            }

            round_3_resultado = "Resultado do round: Desafiador não conseguiu vencer após 10 tentaticas. Vitória do desafiado!";
            Vencedor = Card_B;
            VencedorId = Card_B.Id;
            return round_3_resultado;
        }
        private Card? RoundCalculadora(string escolha, Card card_1, Card card_2)
        {
            switch (escolha)
            {
                case "Forca": return card_1.Forca > card_2.Forca ? card_1 : card_2; break;
                case "Defesa": return card_1.Defesa > card_2.Defesa ? card_1 : card_2; break;
                case "Agilidade": return card_1.Agilidade > card_2.Agilidade ? card_1 : card_2; break;
                case "Inteligência": return card_1.Inteligencia > card_2.Inteligencia ? card_1 : card_2; break;
            }

            return null;
        }

        private void EscreverLog(string log)
        {
            LogBatalha = LogBatalha + "; " + log;
        }

    }
}
