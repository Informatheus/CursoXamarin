using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using App1_NossoChat.View;

namespace App1_NossoChat.ViewModel {
    public class PaginaInicialVM : BaseViewModel {

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

		public PaginaInicialVM(INavigation nav) : base (nav) {
			AcessarCommand = new Command(Acessar);

		}

		private void Acessar(object obj) {
			var user = new Usuario();
			user.nome = Nome;
			user.password = Senha;

			var usuarioLogado = ServicoChat.getUsuario(user);
			if(user == null) {
				Application.Current.MainPage.DisplayAlert("Erro", "Usuário/Senha não conferem", "OK");
			} else {
				App.Current.Properties[KeyLogin] = JsonConvert.SerializeObject(user);
				App.Current.MainPage = new NavigationPage(new Chats());

				var res = App.Current.MainPage.DisplayAlert("teste", "teste", "OK", "Cancel");
			}

		}

		

	}
}
