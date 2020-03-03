namespace App1_NossoChat.Models {
    public class Mensagem {

        private int _id;
        public int id {
            get { return _id; }
            set { _id = value; }
        }

        private int _id_chat;
        public int id_chat {
            get { return _id_chat; }
            set { _id_chat = value; }
        }

        private int _id_usuario;
        public int id_usuario {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        private string _mensagem;
        public string mensagem {
            get { return _mensagem; }
            set { _mensagem = value; }
        }

        private Usuario _usuario;
        public Usuario usuario {
            get { return _usuario; }
            set { _usuario = value; }
        }


    }
}
