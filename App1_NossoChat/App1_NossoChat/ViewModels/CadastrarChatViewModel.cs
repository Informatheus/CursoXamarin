using App1_NossoChat.Models;
using App1_NossoChat.Service;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModels {
    class CadastrarChatViewModel : BaseViewModel {

        private string _mensagem;
        public string Mensagem {
            get => _mensagem;
            set => SetProperty(ref _mensagem, value);
        }

        public string Nome { get; set; }

        public Command CadastrarCommand { get; set; }

        public CadastrarChatViewModel() {
            CadastrarCommand = new Command(CadastrarAction);
        }

        private async void CadastrarAction(object obj) {
            var chat = new Chat() { nome = Nome };
            bool ok = await ServicoChat.insertChat(chat);

            if (ok) {
                PopAsync();
            } else {
                Mensagem = "ERRO: Não foi possivel criar o novo chat";
            }
        }
    }
}
