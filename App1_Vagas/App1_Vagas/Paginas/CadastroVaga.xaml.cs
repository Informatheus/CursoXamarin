using App1_Vagas.Banco;
using App1_Vagas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]

    

    public partial class CadastroVaga : ContentPage {

        Vaga updatingVaga;

        public CadastroVaga() {
            InitializeComponent();

        }

        public CadastroVaga(Vaga vaga) {
            InitializeComponent();

            updatingVaga = vaga;

            NomeVaga.Text = vaga.NomeVaga;
            Quantidade.Text = vaga.Quantidade.ToString();
            Salario.Text = vaga.Salario.ToString();
            Empresa.Text = vaga.Empresa;
            Cidade.Text = vaga.Cidade;
            Descricao.Text = vaga.Descricao;
            TipoContrato.IsToggled = vaga.TipoContrato.Equals("PJ") ? true : false;
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
        }



        private void BtnSalvar_Clicked(object sender, EventArgs e) {

            Vaga vaga;

            if(updatingVaga != null) {
                vaga = updatingVaga;
            } else {
                vaga = new Vaga();
            }
            
            vaga.NomeVaga = NomeVaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContrato = TipoContrato.IsToggled ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            AcessoBanco db = new AcessoBanco();

            if (updatingVaga != null) {
                db.Atualizacao(vaga);
            } else {
                db.Cadastro(vaga);
            }

            Navigation.PopAsync();
        }
    }
}