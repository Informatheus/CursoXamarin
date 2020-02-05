using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage {
        public PickerPage() {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e) {

            DisplayAlert("Picker", String.Format("Você selecionou {0}", ((Picker)sender).SelectedItem.ToString()), "OK");

        }
    }
}