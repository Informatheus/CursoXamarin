using App01_ControleXF.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage {
        public ListViewPage() {
            InitializeComponent();

            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa { Nome = "João", Idade = "15" });
            lista.Add(new Pessoa { Nome = "Felipe", Idade = "18" });
            lista.Add(new Pessoa { Nome = "Guilherme", Idade = "25" });
            lista.Add(new Pessoa { Nome = "Matheus", Idade = "35" });
            lista.Add(new Pessoa { Nome = "Deividi", Idade = "19" });
            lista.Add(new Pessoa { Nome = "Leandro", Idade = "12" });

            ListViewPessoas.ItemsSource = lista;
        }
    }
}