using System.Collections.Generic;
using System.Linq;

namespace JobConsumer.Messages
{
    public class Jogos
    {
        public static List<Jogo> MeusJogos { get; set; }

        public static Jogo PegarJogoPorInicial  (string inicialJogo)
        {
            return MeusJogos.Where(jogo => jogo.Inicial == inicialJogo).First();
        }


        public void Main ()
        {
            Jogos.MeusJogos = new List<Jogo>{
                new Jogo(inicial: "RO", nome: "Ragnarok"),
                new Jogo(inicial: "WF", nome: "Warface"),
                new Jogo(inicial: "Es", nome: "Elsword")
            };

            var jogo = Jogos.PegarJogoPorInicial("RO");
        }
    }
















    public class Jogo 
    {
        public string Inicial { get; set; }
        public string Nome { get; set; }

        public Jogo(string inicial, string nome)
        {
            Inicial = inicial;
            Nome = nome;
        }
    }
}