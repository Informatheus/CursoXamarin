using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App2_Tarefa.Modelos {
    public class GerenciadorTarefa {

        String key = "keyTarefas";

        private List<Tarefa> lista { get; set; }

        public void Salvar(Tarefa tarefa) {

            lista = Listagem();

            lista.Add(tarefa);

            SalvarNoProperties(lista);
        }

        public void Finalizar(int index) {

            lista = Listagem();

            lista[index].Finalizar();

            SalvarNoProperties(lista);

        }

        public void Deletar(int index) {

            lista = Listagem();

            lista.RemoveAt(index);

            SalvarNoProperties(lista);
        }

        public List<Tarefa> Listagem() {

            if (App.Current.Properties.ContainsKey(key)) {

                String listaJson = (String)App.Current.Properties[key];

                return JsonConvert.DeserializeObject<List<Tarefa>>(listaJson);

            } else {
                return new List<Tarefa>();
            }
        }

        private void SalvarNoProperties(List<Tarefa> lista) {

            string listajson = JsonConvert.SerializeObject(lista);

            if (App.Current.Properties.ContainsKey(key)) {

                App.Current.Properties.Remove(key);

                App.Current.Properties[key] = listajson;
            } else {

                App.Current.Properties.Add(key, listajson);

            }

            

            
        }

    }

}
