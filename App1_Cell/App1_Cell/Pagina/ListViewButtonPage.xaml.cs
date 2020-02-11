using App1_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Pagina {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewButtonPage : ContentPage {
        public ListViewButtonPage() {
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

        private void Button_Clicked(object sender, EventArgs e) {
            Funcionario func = (sender as Button).CommandParameter as Funcionario;
            DisplayAlert(func.Nome, "Tirou Férias", "OK");
        }
    }
}