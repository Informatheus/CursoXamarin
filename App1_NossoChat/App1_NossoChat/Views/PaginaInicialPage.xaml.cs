using App1_NossoChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicialPage : ContentPage {
        public PaginaInicialPage() {
            InitializeComponent();

            BindingContext = new PaginaInicialViewModel();
        }
    }
}