using App1_Vagas.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using App1_Vagas.UWP.Banco;
using Windows.Storage;

[assembly:Dependency(typeof(Caminho))]
namespace App1_Vagas.UWP.Banco {
    class Caminho : ICaminho {
        public string GetPath(string NomeBanco) {

            string caminhoPasta = ApplicationData.Current.LocalFolder.Path;

            string caminhoBanco = Path.Combine(caminhoPasta, NomeBanco);

            return caminhoBanco;

        }
    }
}
