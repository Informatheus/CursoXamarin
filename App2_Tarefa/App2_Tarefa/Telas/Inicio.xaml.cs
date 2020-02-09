using App2_Tarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage {
        public Inicio() {
            InitializeComponent();

            CultureInfo culture = new CultureInfo("pt-BR");
            Datahoje.Text = String.Format(DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture),"de");

        }

        protected override void OnAppearing() {
            base.OnAppearing();
            carregarLista();
        }

        private void carregarLista() {

            SLTarefas.Children.Clear();

            List<Tarefa> listaTarefa = new GerenciadorTarefa().Listagem();

            int index = -1;

            foreach (Tarefa tarefa in listaTarefa) {
                index++;
                SLTarefas.Children.Add(LinhaStackLayout(tarefa, index));
            }
        }

        private void ButtonGoCadastro(object sender, EventArgs args) {
            Navigation.PushAsync(new Cadastro());
        }

        [Obsolete]
        public StackLayout LinhaStackLayout(Tarefa tarefa, int index) {

            String UWP = "Imagens/";

            //INSTANCIAR A LINHA
            StackLayout Linha = new StackLayout { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            //INSTANCIAR E ADICIONAR A IMAGEM DE CHECK

            String checkImagePath;

            if (tarefa.isFinalized()) {
                checkImagePath = "CheckOn.png";
            } else {
                checkImagePath = "CheckOff.png";
            }

            if (Device.RuntimePlatform == Device.UWP) {
                checkImagePath = UWP + checkImagePath;
            }

            Image ImagemCheck = new Image { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(checkImagePath) };

            //ImagemCheck.GestureRecognizers.Add(new TapGestureRecognizer(
            //    delegate (View arg1, object arg2) {

            //        new GerenciadorTarefa().Finalizar(index);
            //        carregarLista();
            //    })
            //);

            TapGestureRecognizer checkTap = new TapGestureRecognizer();
            checkTap.Tapped += delegate {

                new GerenciadorTarefa().Finalizar(index);

                carregarLista();
            };

            ImagemCheck.GestureRecognizers.Add(checkTap);

            Linha.Children.Add(ImagemCheck);

            //INSTANCIAR E ADICIONAR A LABEL COM O NOME

            StackLayout stackNome = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Spacing = 0 };

            Label lblTarefa = new Label() { Text = tarefa.Nome, TextColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.Center };

            stackNome.Children.Add(lblTarefa);

            if (tarefa.isFinalized()) {
                Label lblFinalizacao = new Label() { TextColor = Color.Gray, Text = tarefa.Finalizacao.Value.ToString("dd/MM/yyyy - hh:mm") + "h", FontSize = 10 };
                stackNome.Children.Add(lblFinalizacao);
            }

            Linha.Children.Add(stackNome);

            //INSTANCIAR E ADICIONAR A IMAGEM DE PRIORIDADE

            String prioridadeImagePath;

            prioridadeImagePath = "p" + tarefa.Prioridade + ".png";

            if (Device.RuntimePlatform == Device.UWP) {
                prioridadeImagePath = UWP + prioridadeImagePath;
            }

            Image ImagemPrioridade = new Image { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(prioridadeImagePath) };

            Linha.Children.Add(ImagemPrioridade);

            // INSTANCIAR E ADICIONAR IMAGEM DE DELETE
            String deleteImagePath = "Delete.png";

            if (Device.RuntimePlatform == Device.UWP) {
                deleteImagePath = UWP + deleteImagePath;
            }

            Image ImagemDelete = new Image { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(deleteImagePath) };

            //ImagemDelete.GestureRecognizers.Add(new TapGestureRecognizer(

            //    delegate (View arg1, object arg2) {

            //        new GerenciadorTarefa().Deletar(index);

            //        carregarLista();
            //    })
            //);

            TapGestureRecognizer deleteTap = new TapGestureRecognizer();
            deleteTap.Tapped += delegate {

                new GerenciadorTarefa().Deletar(index);

                carregarLista();
            };

            ImagemDelete.GestureRecognizers.Add(deleteTap);

            Linha.Children.Add(ImagemDelete);

            //RETORNA O STACKLAYOUT
            return Linha;

        }

    }
}