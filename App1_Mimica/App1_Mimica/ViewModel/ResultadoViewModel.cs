using App1_Mimica.Model;
using App1_Mimica.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel {




    class ResultadoViewModel {

		private Model.Jogo _Jogo;
		public Command BtnNovoJogo { get; set; }

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
	}
}
