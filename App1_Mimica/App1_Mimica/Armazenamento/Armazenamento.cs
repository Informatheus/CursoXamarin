using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_Mimica.Armazenamento {
    public class Armazenamento {

        public static Jogo Jogo { get; set;}

        public static string[][] Palavras = {
            //Fac
            new string[] {"olho", "língua", "bola", "chinelo", "copo", "ping-pong", "amendoim", "cebola"},
            //Med
            new string[] {"carpinteiro", "programador", "azul", "abelha", "professor", "mecânico", "roda", "gripe"},
            //Dif
            new string[] {"cisterna", "lanterna", "escuro", "filme", "batman", "asa", "notebook", "nuvem"},
        };

    }
}
