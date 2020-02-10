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
    public partial class ViewCellPage : ContentPage {
        public ViewCellPage() {
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
    }
}