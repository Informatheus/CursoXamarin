using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Menu {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage {
        public Master() {
            InitializeComponent();
        }

        private void GoToActivityIndicator(object sender, EventArgs args) {
            Detail = new Controles.ActivityIndicatorPage();
            IsPresented = false;
        }

        private void GoToProgressBar(object sender, EventArgs args) {
            Detail = new Controles.ProgressBarPage();
            IsPresented = false;
        }

        private void GoToBoxView(object sender, EventArgs args) {
            Detail = new Controles.BoxViewPage();
            IsPresented = false;
        }

        private void GoToLabel(object sender, EventArgs args) {
            Detail = new Controles.LabelPage();
            IsPresented = false;
        }

        private void GoToButton(object sender, EventArgs args) {
            Detail = new Controles.ButtonPage();
            IsPresented = false;
        }
    }
}