using App1_Mimica.Model;
using App1_Mimica.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel {
    public class JogoViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public string PalavraOculta { get; set; }

        private string _Palavra;
        public string Palavra {
            get { return _Palavra; }
            set { _Palavra = value; onPropertyChanged("Palavra"); }
        }

        private byte _PalavraPontuacao;
        public byte PalavraPontuacao {
            get { return _PalavraPontuacao; }
            set { _PalavraPontuacao = value; onPropertyChanged("PalavraPontuacao"); }
        }

        private short _Contagem;
        public short Contagem {
            get { return _Contagem; }
            set { _Contagem = value; onPropertyChanged("Contagem"); }
        }

        private bool _ContagemVisible;
        public bool ContagemVisible {
            get { return _ContagemVisible; }
            set { _ContagemVisible = value; onPropertyChanged("ContagemVisible"); }
        }

        private Command _BtnMostrarIniciar;

        public Command BtnMostrarIniciar {
            get { return _BtnMostrarIniciar; }
            set { _BtnMostrarIniciar = value; onPropertyChanged("BtnMostrarIniciar"); }
        }


        //public Command BtnMostrarIniciar { get; set; }
        public Command BtnAcertou { get; set; }
        public Command BtnErrou { get; set; }

        private Grupo _Grupo;

        public Grupo Grupo {
            get { return _Grupo; }
            set { _Grupo = value; onPropertyChanged("Grupo"); }
        }

        private byte _RodadaAtual;

        public byte RodadaAtual {
            get { return _RodadaAtual; }
            set { _RodadaAtual = value; onPropertyChanged("RodadaAtual"); }
        }

        private bool TimerIsOn;


        public JogoViewModel(Grupo grupoRodada, byte RodadaAtual) {
            Grupo = grupoRodada;
            this.RodadaAtual = RodadaAtual;
            BtnMostrarIniciar = new Command(ActionMostrarPalavra);
            BtnAcertou = new Command(ActionAcertou);
            BtnErrou = new Command(ActionErrou);

            ContagemVisible = false;
            Palavra = "********";
            Contagem = Armazenamento.Armazenamento.Jogo.TempoPalavra;
            BuscarPalavra();
        }

        private void onPropertyChanged(string NameProperty) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
        private void ActionErrou(object obj) {
            App.Current.MainPage.DisplayAlert("ERROU!", String.Format("{0} deixou de marcar {1} pontos!", Grupo.Nome, PalavraPontuacao), "OK");
            Finalizacao();

        }

        private void ActionAcertou(object obj) {
            App.Current.MainPage.DisplayAlert("ACERTOU!", String.Format("{0} marcou {1} pontos!", Grupo.Nome, PalavraPontuacao), "OK");
            Grupo.Pontuacao += PalavraPontuacao;
            Finalizacao();
        }

        private void Finalizacao() {
            TimerIsOn = false;


            Grupo ProxGrupo;
            if (Armazenamento.Armazenamento.Jogo.Grupo1 == Grupo) {
                ProxGrupo = Armazenamento.Armazenamento.Jogo.Grupo2;
            } else {
                if (++Armazenamento.Armazenamento.Jogo.RodadaAtual > Armazenamento.Armazenamento.Jogo.Rodadas) {
                    App.Current.MainPage = new Resultado();
                    return;
                }
                ProxGrupo = Armazenamento.Armazenamento.Jogo.Grupo1;
            }
            App.Current.MainPage = new View.Jogo(ProxGrupo, Armazenamento.Armazenamento.Jogo.RodadaAtual);
        }


        private void ActionIniciarJogo(object obj) {
            (obj as Button).Text = "Boa Sorte!";
            (obj as Button).IsEnabled = false;
            ContagemVisible = true;
            IniciarTimer();

        }

        private void IniciarTimer() {

            TimerIsOn = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {

                if (!TimerIsOn) {
                    return false;
                }

                if (Contagem <= 0) {
                    ActionErrou(null);
                    return false;
                }

                Contagem--;

                return true;
            });


        }

        private void BuscarPalavra() {
            byte Nivel = Armazenamento.Armazenamento.Jogo.NivelNumerico;

            Random rd = new Random();

            if (Nivel == 0) {
               
                int niv = rd.Next(0, 3);
                int ind = rd.Next(0, Armazenamento.Armazenamento.Palavras[niv].Length);
                PalavraOculta = Armazenamento.Armazenamento.Palavras[niv][ind];
                PalavraPontuacao = (byte)((niv == 0) ? 1 : (niv == 1) ? 3 : 5);

            } else if (Nivel == 1) {
                
                int ind = rd.Next(0, Armazenamento.Armazenamento.Palavras[Nivel - 1].Length);
                PalavraOculta = Armazenamento.Armazenamento.Palavras[Nivel - 1][ind];
                PalavraPontuacao = 1;

            } else if (Nivel == 2) {
                
                int ind = rd.Next(0, Armazenamento.Armazenamento.Palavras[Nivel - 1].Length);
                PalavraOculta = Armazenamento.Armazenamento.Palavras[Nivel - 1][ind];
                PalavraPontuacao = 3;

            } else if (Nivel == 3) {
                
                int ind = rd.Next(0, Armazenamento.Armazenamento.Palavras[Nivel - 1].Length);
                PalavraOculta = Armazenamento.Armazenamento.Palavras[Nivel - 1][ind];
                PalavraPontuacao = 5;

            }
        }

        private void ActionMostrarPalavra(object obj) {
            BtnMostrarIniciar = new Command(ActionIniciarJogo);
            Palavra = PalavraOculta;

            (obj as Button).Text = "Iniciar";

        }


    }
}
