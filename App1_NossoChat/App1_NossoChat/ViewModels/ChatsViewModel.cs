using App1_NossoChat.Models;
using App1_NossoChat.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    AbrirChat(value);
                }
            }
        }


        public ChatsViewModel() {

            CommandAdicionar = new Command(ActionAdicionar);
            CommandOrdenar = new Command(ActionOrdenar);
            CommandAtualizar = new Command(ActionAtualizar);

        }

        public async void ActionAtualizar() {
            IsBusy = true;
            ListaChats = await ServicoChat.getChats();
            IsBusy = false;
        }

        private void ActionOrdenar() {
            ListaChats = ListaChats.OrderBy(a => a.nome).ToList();
        }

        private async void ActionAdicionar() {
            PushAsync<CadastrarChatViewModel>();
        }

        private async void AbrirChat(Chat chat) {
            PushAsync<MensagensViewModel>(chat);
        }

    }
}
