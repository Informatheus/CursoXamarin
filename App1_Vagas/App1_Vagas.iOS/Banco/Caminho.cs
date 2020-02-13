using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using App1_Vagas.Banco;
using Foundation;
using UIKit;
using App1_Vagas.iOS.Banco;
using Xamarin.Forms;

[assembly:Dependency(typeof(Caminho))]
namespace App1_Vagas.iOS.Banco {
    public class Caminho : ICaminho {
        public string GetPath(string NomeBanco) {

            var caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBiblioteca = Path.Combine(caminhoPasta, "..", "Library");

            string caminhoBanco = Path.Combine(caminhoBiblioteca, NomeBanco);

            return caminhoBanco;

        }
    }
}