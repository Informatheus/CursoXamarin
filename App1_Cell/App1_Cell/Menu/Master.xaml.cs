using App1_Cell.Pagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Menu {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage {
        public Master() {
            InitializeComponent();
        }

        public void GoPagina1(object sender, EventArgs args) {
            Detail = new NavigationPage(new TextCellPage());
        }

        public void GoPagina2(object sender, EventArgs args) {
            Detail = new NavigationPage(new ImageCellPage());
        }

        private void GoPagina3(object sender, EventArgs e) {
            Detail = new NavigationPage(new EntryCellPage());
        }

        private void GoPagina4(object sender, EventArgs e) {
            Detail = new NavigationPage(new SwitchCellPage());
        }

        private void GoPagina5(object sender, EventArgs e) {
            Detail = new NavigationPage(new ViewCellPage());
        }
    }
}