using App1_NossoChat.Models;
using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_NossoChat.ViewModels {
    class ChatsViewModel : BaseViewModel {

		private List<Chat> _listaChats;
		public List<Chat> ListaChats {
			get => _listaChats;
			set => SetProperty(ref _listaChats, value);
		}

		public ChatsViewModel() {
			ListaChats = ServicoChat.getChats();
        }

    }
}
