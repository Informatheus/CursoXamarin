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

        StackLayout Container { get; set; }

        private List<Mensagem> myListaMensagens;
        public List<Mensagem> ListaMensagens {
            get => myListaMensagens;
            set {
                SetProperty(ref myListaMensagens, value);
                ShowOnScreen();
            }
        }

        public MensagensViewModel(Chat chat, StackLayout MensagemContainer) {

            Container = MensagemContainer;
            ListaMensagens = ServicoChat.getMensagens(chat);
            chatAtual = chat;

            BtnEnviar = new Command(EnviarAction);
            AtualizarCommand = new Command(AtualizarAction);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                AtualizarAction(null);
                return true; });
        }

        private void AtualizarAction(object obj) {
            ListaMensagens = ServicoChat.getMensagens(chatAtual);
        }

        private void EnviarAction(object obj) {

            var NovaMsg = new Mensagem() {
                mensagem = TxtMsg, id_chat = chatAtual.id,
                id_usuario = new Usuario(App.Current.Properties[Usuario.KeyLogin] as string).id,
            };

            ServicoChat.insertMensagem(NovaMsg);
            TxtMsg = "";
            AtualizarAction(null);
        }

        private void ShowOnScreen() {
            Container.Children.Clear();
            Usuario usuarioLogado = new Usuario(App.Current.Properties[Usuario.KeyLogin] as string);
            foreach (var msg in ListaMensagens) {
                if (msg.usuario.id == usuarioLogado.id) {
                    Container.Children.Add(CriarMensagemPropria(msg));
                } else {
                    Container.Children.Add(CriarMensagemOutroUsuario(msg));
                }
            }
        }

        private View CriarMensagemPropria(Mensagem mensagem) {
            var layout = new StackLayout() {
                Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End
            };
            var label = new Label() {
                TextColor = Color.White, Text = mensagem.mensagem
            };
            layout.Children.Add(label);
            return layout;
        }

        private View CriarMensagemOutroUsuario(Mensagem mensagem) {
            var labelNome = new Label() {
                Text = mensagem.usuario.nome, FontSize = 10, TextColor = Color.FromHex("#5ED055")
            };

            var labelMsg = new Label() {
                Text = mensagem.mensagem, TextColor = Color.FromHex("#5ED055")
            };

            var SL = new StackLayout();
            SL.Children.Add(labelNome);
            SL.Children.Add(labelMsg);

            var frame = new Frame() {
                BorderColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.StartAndExpand, Content = SL
            };

            return frame;

        }
    }
}
