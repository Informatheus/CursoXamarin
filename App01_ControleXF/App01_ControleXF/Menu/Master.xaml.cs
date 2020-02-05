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
            Detail = new NavigationPage(new Controles.ActivityIndicatorPage());
            IsPresented = false;
        }

        private void GoToProgressBar(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.ProgressBarPage());
            IsPresented = false;
        }

        private void GoToBoxView(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.BoxViewPage());
            IsPresented = false;
        }

        private void GoToLabel(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.LabelPage());
            IsPresented = false;
        }

        private void GoToButton(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.ButtonPage());
            IsPresented = false;
        }
        private void GoToEntryEditor(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.EntryEditorPage());
            IsPresented = false;
        }

        private void GoToDatePicker(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.DatePickerPage());
            IsPresented = false;

        }

        private void GoToTimePicker(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.TimePickerPage());
            IsPresented = false;
        }

        private void GoToPicker(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.PickerPage());
            IsPresented = false;
        }

        private void GoToSearchBar(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.SearchBarPage());
            IsPresented = false;
        }

        private void GoToSliderStepper(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.SlidderStepperPage());
            IsPresented = false;
        }

        private void GoToSwitch(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.SwitchPage());
            IsPresented = false;
        }

        private void GoToImage(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.ImagePage());
            IsPresented = false;
        }
        private void GoToListView(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.ListViewPage());
            IsPresented = false;

        }

        private void GoToTableView(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.TableViewPage());
            IsPresented = false;
        }

        private void GoToWebView(object sender, EventArgs args) {
            Detail = new NavigationPage(new Controles.WebViewPage());
            IsPresented = false;
        }
    }
}
   