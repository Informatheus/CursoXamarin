using App1_NossoChat.Models;
using App1_NossoChat.Service;
using App1_NossoChat.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModels {
    public class PaginaInicialViewModel : BaseViewModel {

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

        private async void Acessar() {
            IsBusy = true;
            var user = new Usuario();
            user.nome = Nome;
            user.password = Senha;

            var usuarioLogado = await ServicoChat.getUsuario(user);
            IsBusy = false;
            if (usuarioLogado == null) {
                DisplayAlert("Erro", "Usuário/Senha não conferem", "OK");
            } else {
                App.Current.Properties[Usuario.KeyLogin] = usuarioLogado.GetJSON();
                //PushAsync<ChatsViewModel>(); Não, porque precisamos da Navigation
                App.Current.MainPage = new NavigationPage(new ChatsPage()) {
                    BarBackgroundColor = (Color)App.Current.Resources["Verdeapp"], BarTextColor = Color.White };
            }


        }



    }
}
