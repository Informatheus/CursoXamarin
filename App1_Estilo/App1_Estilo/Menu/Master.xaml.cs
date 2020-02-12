using App1_Estilo.Pagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Estilo.Menu {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage {
        public Master() {
            InitializeComponent();
        }

        private void GoPagina1(object sender, EventArgs args) {
            Detail = new NavigationPage(new ImplicitStylePage());
            IsPresented = false;
        }

        private void GoPagina2(object sender, EventArgs args) {
            Detail = new NavigationPage(new ExplicitStylePage());
            IsPresented = false;
        }

        private void GoPagina3(object sender, EventArgs args) {
            Detail = new NavigationPage(new GlobalStylePage());
            IsPresented = false;
        }

        private void GoPagina4(object sender, EventArgs args) {
            Detail = new NavigationPage(new InheritStylePage());
            IsPresented = false;
        }

        private void GoPagina5(object sender, EventArgs args) {
            Detail = new NavigationPage(new DynamicStylePage());
            IsPresented = false;
        }
    }
}