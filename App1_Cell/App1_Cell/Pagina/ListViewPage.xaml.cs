using App1_Cell.Modelo;
using App1_Cell.Pagina.Detalhe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Pagina {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage {
        public ListViewPage() {
            InitializeComponent();

            List<Funcionario> lista = new List<Funcionario>();
            lista.Add(new Funcionario { Nome = "José", Cargo = "Presidente" });
            lista.Add(new Funcionario { Nome = "Maria", Cargo = "Gerente de Vendas" });
            lista.Add(new Funcionario { Nome = "Elaine", Cargo = "Gerente de Marketing" });
            lista.Add(new Funcionario { Nome = "Felipe", Cargo = "Entregador" });
            lista.Add(new Funcionario { Nome = "João", Cargo = "Vendedor" });
            lista.Add(new Funcionario { Nome = "Matheus", Cargo = "Enxugador de Gelo" });

            ListaFuncionario.ItemsSource = lista;

        }

        private void ListaFuncionario_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            Funcionario func = e.SelectedItem as Funcionario;
            Navigation.PushAsync(new DetailPage(func));
        }

        private void MenuItem_Clicked_Ferias(object sender, EventArgs e) {
            Funcionario func = (sender as MenuItem).CommandParameter as Funcionario;
            DisplayAlert(func.Nome, "Tirou Férias", "OK");
        }

        private void MenuItem_Clicked_Abono(object sender, EventArgs e) {

        }
    }
}