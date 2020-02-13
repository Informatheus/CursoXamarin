using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using App1_Vagas.Modelo;
using Xamarin.Forms;

namespace App1_Vagas.Banco {
    class AcessoBanco {

        private SQLiteConnection _conexao;

        public AcessoBanco() {

            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.GetPath("Database.sql");

            _conexao = new SQLiteConnection(caminho);

            _conexao.CreateTable<Vaga>();

        }

        public void Cadastro(Vaga vaga) {
            _conexao.Insert(vaga);
        }

        public void Exclusao (Vaga vaga) {
            _conexao.Delete(vaga);
        }

        public void Atualizacao(Vaga vaga) {
            _conexao.Update(vaga);
        }

        public List<Vaga> Consultar() {
            return _conexao.Table<Vaga>().ToList();
        }

        public List<Vaga> PesquisarPalavraChave(string palavra) {
            return _conexao.Table<Vaga>().Where(x => x.NomeVaga.Contains(palavra)).ToList();
        }

        public Vaga ConsultaPorID(int id) {
            return _conexao.Table<Vaga>().Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
