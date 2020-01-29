using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {
        
            string cep = CEP.Text.Trim();            

            if (isValidCEP(cep)){

            Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

            if (end != null) { 
                Resultado.Text = string.Format("Endereço: {0}, {1} {2}", end.localidade, end.uf, end.logradouro);
            } else {
                    DisplayAlert("ERRO", "Não existe este CEP", "OK");
                }   

            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido, o CEP deve conter 8 caracteres", "OK");
                valido = false;
            }
            int novoCEP = 0;

            if(!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido, o CEP deve conter apenas números", "OK");
                valido = false;
            }
            return valido;
        }       
    }
}
