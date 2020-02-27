using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using App1_NossoChat.Models;

namespace App1_NossoChat.Service {
    public class ServicoChat {

        const string url = "http://ws.spacedu.com.br/xf2018/rest/api/";

        public static Usuario getUsuario(Usuario usuario) {

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("nome",usuario.nome),
            new KeyValuePair<string,string>("password",usuario.password)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url + "usuario", parametros).GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return JsonConvert.DeserializeObject<Usuario>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }

            return null;
        }

        public static List<Chat> getChats() {

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = requisicao.GetAsync(url + "chats").GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {

                List<Chat> lista = JsonConvert.DeserializeObject<List<Chat>>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                if (lista.Count > 0) {
                    return lista;
                }

            }

            return null;
        }

        public static bool insertChat(Chat chat) {

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("nome",chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url + "chat", parametros).GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }

        public static bool updateChat(Chat chat) {
            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("nome",chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PutAsync(url + "chat/" + chat.id, parametros).GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }

        public static bool deleteChat(Chat chat) {

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = requisicao.DeleteAsync(url + "chats/delete/" + chat.id).GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }

        public static List<Mensagem> getMensagens(Chat chat) {

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = requisicao.GetAsync(url + "chat/" + chat.id + "/msg").GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {

                List<Mensagem> lista = JsonConvert.DeserializeObject<List<Mensagem>>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                if (lista.Count > 0) {
                    return lista;
                }
            }

            return null;
        }

        public static bool insertMensagem(Mensagem mensagem) {


            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("id_chat",mensagem.id_chat.ToString()),
            new KeyValuePair<string,string>("id_usuario",mensagem.id_usuario.ToString()),
            new KeyValuePair<string,string>("mensagem",mensagem.mensagem)
            }); ;

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url + "chat/" + mensagem.id_chat + "/msg", parametros).GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }
        
        public static bool deleteMensagem(Mensagem mensagem) {

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = requisicao.DeleteAsync(url + "chat/" + mensagem.id_chat + "/delete/" + mensagem.id).GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }


    }
}
