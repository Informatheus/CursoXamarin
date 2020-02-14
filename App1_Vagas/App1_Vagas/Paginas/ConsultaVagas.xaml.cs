using App1_Vagas.Banco;
using App1_Vagas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaVagas : ContentPage {

        private List<Vaga> Lista;

        public ConsultaVagas() {
            InitializeComponent();


        }

        protected override void OnAppearing() {
            base.OnAppearing();

            CarregarDados();

        }

        private void CarregarDados() {

            AcessoBanco db = new AcessoBanco();

            Lista = db.Consultar();

            ListaVagas.ItemsSource = Lista;

            LblCount.Text = Lista.Count.ToString() + " vagas cadastradas.";

            if( CampoPesquisa.Text != null) {
                ListaVagas.ItemsSource = Lista.Where(x => x.NomeVaga.ToLower().Contains(CampoPesquisa.Text.ToLower())).ToList();
            }
        }

        public void GoCadastro(object sender, EventArgs args) {
            Navigation.PushAsync(new CadastroVaga());
        }

        public void GoMinhasVagas(object sender, EventArgs args) {
            Navigation.PushAsync(new VagasCadastradas());
        }

        public void DetalhesClicked(object sender, EventArgs args) {

            Vaga vaga = (((sender as Label).GestureRecognizers[0] as TapGestureRecognizer).CommandParameter as Vaga);

            Navigation.PushAsync(new DetalheVaga(vaga));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs args) {

            ListaVagas.ItemsSource = Lista.Where(x => x.NomeVaga.ToLower().Contains(args.NewTextValue.ToLower())).ToList();

        }
    }
}