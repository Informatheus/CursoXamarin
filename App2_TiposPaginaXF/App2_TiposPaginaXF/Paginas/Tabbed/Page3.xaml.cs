using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_TiposPaginaXF.Paginas.Tabbed {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage {
        public Page3() {
            InitializeComponent();
        }

        private void irParaMaster(object sender, EventArgs args) {
            Navigation.PushAsync(new Master.Master());
            //App.Current.MainPage = new NavigationPage(new Master.Master());
        }
    }
}