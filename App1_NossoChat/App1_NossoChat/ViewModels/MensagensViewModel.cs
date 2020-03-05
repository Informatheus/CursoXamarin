using App1_NossoChat.Models;
using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModels {
    class MensagensViewModel : BaseViewModel {

        private Chat chatAtual { get; set; }

        private string myTxtMsg;
        public string TxtMsg {
            get => myTxtMsg;
            set => SetProperty(ref myTxtMsg, value);
        }

        public Command AtualizarCommand { get; set; }
        public Command BtnEnviar { get; set; }

        private List<Mensagem> myListaMensagens;
        public List<Mensagem> ListaMensagens {
            get => myListaMensagens;
            set => SetProperty(ref myListaMensagens, value);
        }

        public MensagensViewModel(Chat chat) {

            chatAtual = chat;

            AtualizarAction();

            BtnEnviar = new Command(EnviarAction);
            AtualizarCommand = new Command(AtualizarAction);

            Device.StartTimer(TimeSpan.FromSeconds(3), () => {
                AtualizarAction();
                return true;
            });
        }

        private async void AtualizarAction() {
            IsBusy = true;
            CarregarNovasMensagens();
            IsBusy = false;
        }

        private async void CarregarNovasMensagens() {
            List<Mensagem> NovaLista = await ServicoChat.getMensagens(chatAtual);
            if (ListaMensagens == null || ListaMensagens.Count != NovaLista.Count) {
                ListaMensagens = NovaLista;
            }
        }

        private void EnviarAction(object obj) {

            var NovaMsg = new Mensagem() {
                mensagem = TxtMsg, id_chat = chatAtual.id,
                id_usuario = new Usuario(App.Current.Properties[Usuario.KeyLogin] as string).id,
            };

            ServicoChat.insertMensagem(NovaMsg);
            TxtMsg = "";

            //isso não é necessario se Device.Timer está on
            //AtualizarAction(false);
        }

    }
}
