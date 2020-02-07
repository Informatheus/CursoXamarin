using System;
using System.Collections.Generic;
using System.Text;

namespace App2_Tarefa.Modelos {
    public class GerenciadorTarefa {

        String key = "keyTarefas";

        //private List<Tarefa> lista { get; set; }

        public void Salvar(Tarefa tarefa) {
            List<Tarefa> lista;
            if (App.Current.Properties.ContainsKey(key)) {
                //lista = (List<Tarefa>)App.Current.Properties.TryGetValue(key, new List<Tarefa>());
            }



        }

        public void Finalizar(Tarefa tarefa) {

        }

        public List<Tarefa> Listagem() {
            return null;
        }

        public void Remover(Tarefa tarefa) {

        }

        private void SalvarNoProperties(List<Tarefa> lista) {


        }

    }
}
