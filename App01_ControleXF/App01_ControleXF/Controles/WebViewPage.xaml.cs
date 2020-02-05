using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles {
    [XamlCompilation(XamlCompilationOptions.Compile)]

   
    public partial class WebViewPage : ContentPage {

        public WebViewPage() {
            InitializeComponent();
        }

        private void Button_Clicked_ok(object sender, EventArgs e) {
            Navegador.Source = EnderecoSite.Text;
        }

        private void Button_Clicked_anterior(object sender, EventArgs e) {
            if (Navegador.CanGoBack) {
                Navegador.GoBack();
            }
        }

        private void Button_Clicked_proximo(object sender, EventArgs e) {
            if (Navegador.CanGoForward) {
                Navegador.GoForward();
            }
        }
    }
}