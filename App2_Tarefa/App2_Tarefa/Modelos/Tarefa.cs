using System;
using System.Collections.Generic;
using System.Text;

namespace App2_Tarefa.Modelos {
    public class Tarefa {

        public String Nome { get; set; }
        public DateTime? Finalizacao { get; set; }
        public byte Prioridade { get; set; }

        public void Finalizar() {
            if (Finalizacao == null) {
                Finalizacao = DateTime.Now;
            }

        }

        public Boolean isFinalized() {
            if (Finalizacao != null) return true;
            else return false; 
        }


    }
}