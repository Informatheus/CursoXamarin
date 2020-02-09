using App2_Tarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage {

        private byte Prioridade { get; set; }

        public Cadastro() {
            InitializeComponent();
        }

        private void PrioridadeSelectAction(object sender, EventArgs e) {

            var Stacks = SLPrioridades.Children;

            foreach(var linha in Stacks) {
                Label lblPrioridade = ((StackLayout)linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            (((StackLayout)sender).Children[1] as Label).TextColor = Color.Black;


            FileImageSource source = (((StackLayout)sender).Children[0] as Image).Source as FileImageSource;

            String stringPrioridade = source.File.ToString().Replace("Imagens/","").Replace(".png","").Replace("p", "");

            Prioridade = byte.Parse(stringPrioridade);


        }

        private void Button_Clicked(object sender, EventArgs e) {
            if (TxtNome.Text == "" || TxtNome.Text == null) {
                DisplayAlert("ERRO", "Insira um nome", "OK");
                return;
            }

            if (Prioridade == 0) {
                DisplayAlert("ERRO", "Selecione uma prioridade", "OK");
                return;
            }

            Tarefa tarefa = new Tarefa();
            tarefa.Nome = TxtNome.Text.Trim();
            tarefa.Prioridade = this.Prioridade;

            new GerenciadorTarefa().Salvar(tarefa);

            //App.Current.MainPage = new NavigationPage(new Inicio());
            Navigation.PopAsync();


        }
    }
}