using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel {
    class InicioViewModel : INotifyPropertyChanged {

        public Jogo NovoJogo {get;set;}
        public Command CommandIniciar { get; set; }

        public InicioViewModel() {
            CommandIniciar = new Command(IniciarJogo);
            NovoJogo = new Jogo();

        }
        private void IniciarJogo() {

            Armazenamento.Armazenamento.Jogo = NovoJogo;
            App.Current.MainPage = new View.Jogo(NovoJogo.Grupo1, NovoJogo.RodadaAtual);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NameProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
