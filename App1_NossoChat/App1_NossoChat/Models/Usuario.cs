using Newtonsoft.Json;

namespace App1_NossoChat.Models {


    public class Usuario {

        public const string KeyLogin = "LOGIN";

        public Usuario() {

        }

        public Usuario(string JsonUsuario) {
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(JsonUsuario);
            id = usuario.id;
            nome = usuario.nome;
            password = usuario.password;

        }

        private int _id;
        public int id {
            get { return _id; }
            set { _id = value; }
        }

        private string _nome;
        public string nome {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _senha;
        public string password {
            get { return _senha; }
            set { _senha = value; }
        }

        public string GetJSON() {
            return JsonConvert.SerializeObject(this);
        }

    }

}
