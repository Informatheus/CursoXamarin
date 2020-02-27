using App1_NossoChat.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new PaginaInicialPage();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
