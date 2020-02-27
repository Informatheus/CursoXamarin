using System;
using System.Collections.Generic;
using System.Text;

namespace App1_NossoChat.Models {
    public class Chat {

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

    }
}
