using System;

namespace E_Players_AspNetCore.Models
{
    public class Partida
    {
        // Atributos da Classe Partida
        public int IdPartida { get; set; } //Exemplo - 1
        public int IdJogador1 { get; set; } //Exemplo - 1
        public int IdJogador2 { get; set; } //Exemplo - 1
        public DateTime HorarioInicio {get; set;} //Exemplo - 12:12:12
        public DateTime HorarioTermino {get; set;}//Exemplo - 00:00:00
        
    }
}