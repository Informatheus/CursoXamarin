using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_Xamarin.Master {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage {
        public Menu() {
            InitializeComponent();
        }

        private void GoPerfil(object sender, EventArgs args) {
            //Navigation.PushAsync(new Pages.Perfil1());
            //Apesar de estar definida para o Detail em Menu.xaml, o Menu.xaml.cs não está sob
            // uma instância de NavigationPage, por isso não podemos usar Navigation.PushAsync();
            Detail = new NavigationPage(new Pages.Perfil1());
            IsPresented = false;

        }

        private void GoXamarin(object sender, EventArgs args) {
            //Navigation.PushAsync(new Pages.Xamarin());
            //Apesar de estar definida para o Detail em Menu.xaml, o Menu.xaml.cs não está sob
            // uma instância de NavigationPage, por isso não podemos usar Navigation.PushAsync();
            Detail = new NavigationPage(new Pages.Xamarin());
            IsPresented = false;
        }
    }
}