using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using App1_NossoChat.Views;

namespace App1_NossoChat.ViewModels {
    public class PaginaInicialViewModel : BaseViewModel {

        private const string KeyLogin = "LOGIN";

        private string _nome;
        public string Nome {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _senha;
        public string Senha {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        public Command AcessarCommand { get; set; }

        public PaginaInicialViewModel() {
            AcessarCommand = new Command(Acessar);

            Nome = "matheus";
            Senha = "123";

        }

        private void Acessar(object obj) {
            var user = new Usuario();
            user.nome = Nome;
            user.password = Senha;

            var usuarioLogado = ServicoChat.getUsuario(user);
            if (usuarioLogado == null) {
                DisplayAlert("Erro", "Usuário/Senha não conferem", "OK");
            } else {
                App.Current.Properties[KeyLogin] = JsonConvert.SerializeObject(user);
                //PushAsync<ChatsViewModel>();
                App.Current.MainPage = new NavigationPage(new ChatsPage()) {
                    BarBackgroundColor = (Color)App.Current.Resources["Verdeapp"], BarTextColor = Color.White };
            }

        }



    }
}
