using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_TiposPaginaXF.Paginas.Navigation {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3Modal : ContentPage {
        public Page3Modal() {
            InitializeComponent();
        }

        private void FecharModal(object sender, System.EventArgs args) {
            Navigation.PopModalAsync();
        }
    }
}