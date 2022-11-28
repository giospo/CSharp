using RpgApi.Models.Enuns;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace RpgApi.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PontosVida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Inteligencia { get; set; }
        public ClasseEnum Classe { get; set; }
        public byte[] FotoPersonagem { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; } // Declaramos o Usuário aqui para podermos verificar a qual Usuário o Personagem está atrelado

        [JsonIgnore]
        public Arma Arma { get; set; }
        public List<PersonagemHabilidade> PersonagemHabilidades { get; set; }
        public int Disputas { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
    }
}