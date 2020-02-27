using App1_NossoChat.Models;
using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModels {
    class ChatsViewModel : BaseViewModel {

        public Command CommandAtualizar { get; set; }
        public Command CommandOrdenar { get; set; }
        public Command CommandAdicionar { get; set; }

        private List<Chat> _listaChats;
        public List<Chat> ListaChats {
            get => _listaChats;
            set => SetProperty(ref _listaChats, value);
        }

        public ChatsViewModel() {

            ListaChats = ServicoChat.getChats();

            CommandAdicionar = new Command(ActionAdicionar);
            CommandOrdenar = new Command(ActionOrdenar);
            CommandAtualizar = new Command(ActionAtualizar);

        }

        private void ActionAtualizar(object obj) {
            ListaChats = ServicoChat.getChats();
        }

        private void ActionOrdenar(object obj) {
            ListaChats = ListaChats.OrderBy(a => a.nome).ToList();
        }

        private void ActionAdicionar(object obj) {
            PushAsync<CadastrarChatViewModel>();
        }

    }
}
