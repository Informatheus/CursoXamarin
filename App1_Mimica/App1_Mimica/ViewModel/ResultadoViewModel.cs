using App1_Mimica.Model;
using App1_Mimica.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel {




    class ResultadoViewModel : INotifyPropertyChanged {

		

		public event PropertyChangedEventHandler PropertyChanged;

		public Command BtnNovoJogo { get; set; }

		private Model.Jogo _Jogo;
		public Model.Jogo Jogo {
			get { return _Jogo; }
			set { _Jogo = value; }
		}

		public ResultadoViewModel() {
			Jogo = Armazenamento.Armazenamento.Jogo;
			BtnNovoJogo = new Command(ActionNovoJogo);
		}

		private void ActionNovoJogo(object obj) {
			App.Current.MainPage = new View.Inicio();
		}

		private void OnPropertyChanged(string NameProperty) {
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
			}
		}
	}
}
