using App1_NossoChat.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicialPage : ContentPage {
        public PaginaInicialPage() {
            InitializeComponent();

            BindingContext = new PaginaInicialViewModel();


        }

        private void Button_Clicked(object sender, System.EventArgs e) {
            Carregando.IsVisible = true;
        }
    }
}