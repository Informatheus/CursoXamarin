using App1_NossoChat.Models;
using App1_NossoChat.Service;
using System.Collections.Generic;
using System.Linq;
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

        private Chat _selectedChat;
        public Chat SelectedChat {
            get => _selectedChat;
            set {
                SetProperty(ref _selectedChat, value);

                if (value != null) {
                    PushAsync<MensagensViewModel>(value);
                }
            }
        }


        public ChatsViewModel() {

            CommandAdicionar = new Command(ActionAdicionar);
            CommandOrdenar = new Command(ActionOrdenar);
            CommandAtualizar = new Command(ActionAtualizar);

        }

        public void ActionAtualizar(object obj) {
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
