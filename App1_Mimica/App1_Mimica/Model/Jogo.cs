using System;
using System.Collections.Generic;
using System.Text;

namespace App1_Mimica.Model {
    public class Jogo {

        public Grupo Grupo1 { get; set; }
        public Grupo Grupo2 { get; set; }
        public string Nivel { get; set; }
        public short TempoPalavra { get; set; }
        public byte Rodadas { get; set; }
        public byte RodadaAtual { get; set; }
        public byte NivelNumerico { get; set; }

        public Jogo() {
            Grupo1 = new Grupo() { Nome = "Grupo 1" };
            Grupo2 = new Grupo() { Nome = "Grupo 2" };
            RodadaAtual = 1;
            TempoPalavra = 120;
            Rodadas = 3;
        }
    }


}
