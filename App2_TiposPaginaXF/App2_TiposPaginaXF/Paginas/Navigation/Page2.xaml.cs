
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_TiposPaginaXF.Paginas.Navigation {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage {
        public Page2() {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs args) {
            //abrir com retorno
            //App.Current.MainPage = new NavigationPage(new Tabbed.Abas());

            //abrir sem retorno
            Navigation.PushAsync(new Tabbed.Abas());
        }
    }
}