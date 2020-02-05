using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBarPage : ContentPage {

        List<String> empresas;

        public SearchBarPage() {
            InitializeComponent();

            iniciarLista();
            preencherView(empresas);

        }

        private void iniciarLista() {
            empresas = new List<String>() { "Microsoft", "Apple", "Oracle", "IBM", "SAP", "Uber", "99Taxi" };
        }

        private void preencherView(List<String> lista) {
            ListResult.Children.Clear();
            lista.ForEach(x => ListResult.Children.Add(new Label() { Text = x }));
        }


        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {
            var resultadoPesquisa = empresas.Where(a => a.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
            preencherView(resultadoPesquisa);

        }

    }

}