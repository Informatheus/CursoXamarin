using App1_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Pagina {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageCellPage : ContentPage {
        public ImageCellPage() {
            InitializeComponent();

            List<Funcionario> lista = new List<Funcionario>();
            lista.Add(new Funcionario { Nome = "José", Cargo = "Presidente", Foto= "https://cimentoitambe.com.br/wp-content/uploads/2010/04/Anderson-Belea.jpg"});
            lista.Add(new Funcionario { Nome = "Maria", Cargo = "Gerente de Vendas", Foto = "https://scontent-gru1-1.xx.fbcdn.net/v/t1.0-9/65114558_2138455396277118_6845141734733643776_n.jpg?_nc_cat=104&_nc_ohc=hu2eb6QGx3cAX-k-srL&_nc_ht=scontent-gru1-1.xx&oh=9299134fcc3f57d2fff214e62ee76204&oe=5ED358A9" });
            lista.Add(new Funcionario { Nome = "Elaine", Cargo = "Gerente de Marketing", Foto= "https://scontent-gru2-1.xx.fbcdn.net/v/t1.0-9/s960x960/78964609_10214924208362614_8164538868972912640_o.jpg?_nc_cat=109&_nc_ohc=COO_a5Yu_60AX-_JeYV&_nc_ht=scontent-gru2-1.xx&oh=9dd84b52e10752c087bdc566a6c0058b&oe=5F0100DA" });
            lista.Add(new Funcionario { Nome = "Felipe", Cargo = "Entregador", Foto= "https://scontent-gru2-2.xx.fbcdn.net/v/t1.0-9/s960x960/52569216_690082318060200_3276500704667107328_o.jpg?_nc_cat=106&_nc_ohc=jFDwAggmO8IAX9VExgM&_nc_ht=scontent-gru2-2.xx&oh=ec4f12e827e8c298fd2cfdcc7b385a40&oe=5EC7BAE2" });
            lista.Add(new Funcionario { Nome = "João", Cargo = "Vendedor", Foto = "https://scontent-gru2-1.xx.fbcdn.net/v/t1.0-9/p960x960/62259076_629362740912014_1672107789981319168_o.jpg?_nc_cat=109&_nc_ohc=VKj3CfvuFFwAX9cVoFR&_nc_ht=scontent-gru2-1.xx&_nc_tp=6&oh=f87537946e085ba43f395280c6c44148&oe=5EC4C538" }); ;
            lista.Add(new Funcionario { Nome = "Matheus", Cargo = "Enxugador de Gelo", Foto= "https://scontent-gru1-1.xx.fbcdn.net/v/t1.0-9/s960x960/67810620_3537611406250810_8848781065360244736_o.jpg?_nc_cat=110&_nc_ohc=Q6vo-RWfe4oAX_roU98&_nc_ht=scontent-gru1-1.xx&oh=773ce176c66c403cab63159518c2d5c7&oe=5ED26104" });

            ListaFuncionario.ItemsSource = lista;

        }
    }
}