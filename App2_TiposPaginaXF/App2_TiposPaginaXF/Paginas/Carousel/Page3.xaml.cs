using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_TiposPaginaXF.Paginas.Carousel {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage {
        public Page3() {
            InitializeComponent();
        }

        private void MudarPagina(object sender, EventArgs args) {
            App.Current.MainPage = new NavigationPage(new Navigation.Page1()) { BarBackgroundColor = Color.Blue };
            //App.Current.MainPage = new Navigation.Page1();
        }

    }


}