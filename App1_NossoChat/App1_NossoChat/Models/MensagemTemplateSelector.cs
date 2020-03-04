using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.Models {
    public class MensagemTemplateSelector : DataTemplateSelector {

        public DataTemplate MinhaMensagem { get; set; }
        public DataTemplate OutraMensagem { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            return ((Mensagem)item).usuario.id == Usuario.GetUsuarioLogado().id ? MinhaMensagem : OutraMensagem;
        }
    }
}
