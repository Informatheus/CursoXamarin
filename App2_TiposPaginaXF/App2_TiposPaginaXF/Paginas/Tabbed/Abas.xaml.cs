using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_TiposPaginaXF.Paginas.Tabbed {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Abas : TabbedPage {
        public Abas() {
            InitializeComponent();

            //adiciona abas dinamicamente
            //Children.Add(new NavigationPage(new Page2()) { Title = "Aba 2" });
        }
    }
}