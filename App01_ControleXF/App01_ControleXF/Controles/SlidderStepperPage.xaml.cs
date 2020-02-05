using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlidderStepperPage : ContentPage {
        public SlidderStepperPage() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e) {
            SliderResult.Text = ((int)e.NewValue).ToString();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e) {
            StepperResult.Text = e.NewValue.ToString();
        }
    }
}