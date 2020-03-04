using App3_JWTAsync.Service;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace App3_JWTAsync {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private async void GetTokenAction(object sender, EventArgs e) {
            string resultado = await JWTService.GetToken(Nome.Text, Password.Text);
            LblToken.Text = resultado;
        }

        private async void VerificarAction(object sender, EventArgs e) {
            string resultado = await JWTService.VerificarToken();
            LblResultado.Text = resultado;
        }

        //        Nota:

        //Caso você queira acionar um método async usando MVVM ou dentro de um método normal(sem async na assinatura do método). Use o trecho:

        //Namespace: System.Threading.Task;
        //Task.Run(async()=>{
        //await SeuMétodoAsync();
        //    }); 

        //Obs.: Pode ser usado em métodos chamados pelo Command ou Método Construtor e outros métodos que não se podem mudar a assinatura acrescentando Async.


    }
}
