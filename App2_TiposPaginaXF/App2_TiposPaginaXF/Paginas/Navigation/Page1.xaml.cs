using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_TiposPaginaXF.Paginas.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Navigation.Page2());
        }

        private void OnButton2Clicked(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new Navigation.Page3Modal());
        }

    }
}
