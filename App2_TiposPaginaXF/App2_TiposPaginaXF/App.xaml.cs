using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_TiposPaginaXF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new App2_TiposPaginaXF.Paginas.Carousel.Page3();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
