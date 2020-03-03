using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2_SOAPClient {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e) {
            var n1 = int.Parse(Num1.Text);
            var n2 = int.Parse(Num2.Text);

            TxtResultado.Text = DependencyService.Get<IServiceSOAP>().Somar(n1, n2);
        }
    }
}
