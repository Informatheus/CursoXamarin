using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jogo : ContentPage {
        public Jogo() {
            InitializeComponent();
        }

        private void Mostrar_Button_Clicked(object sender, EventArgs e) {
            (sender as Button).Text = "Iniciar";
            StackContagem.IsVisible = true;
        }

        private void Acertou_Button_Clicked(object sender, EventArgs e) {

        }

        private void Errou_Button_Clicked(object sender, EventArgs e) {

        }
    }
}