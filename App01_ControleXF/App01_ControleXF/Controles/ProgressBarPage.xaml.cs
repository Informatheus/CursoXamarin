using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarPage : ContentPage {
        public ProgressBarPage() {
            InitializeComponent();

            Label1.Text="BounceIn";
            Label2.Text = "BounceOut";
            Label3.Text = "CubicIn";
            Label4.Text = "CubicInOut";
            Label5.Text = "CubicOut";
            Label6.Text = "SinIn";
            Label7.Text = "SinInOut";
            Label8.Text = "SinOut";
            Label9.Text = "SpringIn";
            Label10.Text = "SpringOut";
        }

        private void Modificar(object sender, EventArgs args) {
            Bar1.ProgressTo(1, 15000, Easing.BounceIn);
            Bar2.ProgressTo(1, 15000, Easing.BounceOut);
            Bar3.ProgressTo(1, 15000, Easing.CubicIn);
            Bar4.ProgressTo(1, 15000, Easing.CubicInOut);
            Bar5.ProgressTo(1, 15000, Easing.CubicOut);
            Bar6.ProgressTo(1, 15000, Easing.SinIn);
            Bar7.ProgressTo(1, 15000, Easing.SinInOut);
            Bar8.ProgressTo(1, 15000, Easing.SinOut);
            Bar9.ProgressTo(1, 15000, Easing.SpringIn);
            Bar10.ProgressTo(1, 15000, Easing.SpringOut);

        }
    }
}