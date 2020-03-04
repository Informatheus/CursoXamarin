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

            ListaMensagens = ServicoChat.getMensagens(chat);
            chatAtual = chat;

            BtnEnviar = new Command(EnviarAction);
            AtualizarCommand = new Command(AtualizarAction);

            //Device.StartTimer(TimeSpan.FromSeconds(1), () => {
            //    AtualizarAction();
            //    return true; });
        }

        private void AtualizarAction() {
            ListaMensagens = ServicoChat.getMensagens(chatAtual);
        }

        private void EnviarAction(object obj) {

            var NovaMsg = new Mensagem() {
                mensagem = TxtMsg, id_chat = chatAtual.id,
                id_usuario = new Usuario(App.Current.Properties[Usuario.KeyLogin] as string).id,
            };

            ServicoChat.insertMensagem(NovaMsg);
            TxtMsg = "";
            AtualizarAction();
        }

    }
}
