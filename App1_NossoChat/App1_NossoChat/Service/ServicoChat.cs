using App1_NossoChat.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace App1_NossoChat.Service {
    public static class ServicoChat {

        const string url = "http://ws.spacedu.com.br/xf2018/rest/api/";

        public static async Task<Usuario> getUsuario(Usuario usuario) {

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("nome",usuario.nome),
            new KeyValuePair<string,string>("password",usuario.password)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.PostAsync(url + "usuario", parametros);

            if (resposta.StatusCode == HttpStatusCode.OK) {
                return JsonConvert.DeserializeObject<Usuario>( await resposta.Content.ReadAsStringAsync());
            }

            return null;
        }

        public static async Task<List<Chat>> getChats() {

            List<Chat> lista = new List<Chat>();

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = await requisicao.GetAsync(url + "chats");

            if (resposta.StatusCode == HttpStatusCode.OK) {

                lista = JsonConvert.DeserializeObject<List<Chat>>( await resposta.Content.ReadAsStringAsync());

            }

            return lista;

        }

        public static async Task <bool> insertChat(Chat chat) {

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("nome",chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.PostAsync(url + "chat", parametros);
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }

        public static async Task<bool> updateChat(Chat chat) {
            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("nome",chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.PutAsync(url + "chat/" + chat.id, parametros);
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }

        public static async Task<bool> deleteChat(Chat chat) {

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = await requisicao.DeleteAsync(url + "chats/delete/" + chat.id);
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }

        public static async Task<List<Mensagem>> getMensagens(Chat chat) {

            List<Mensagem> lista = new List<Mensagem>();

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = await requisicao.GetAsync(url + "chat/" + chat.id + "/msg");
            if (resposta.StatusCode == HttpStatusCode.OK) {

                lista = JsonConvert.DeserializeObject<List<Mensagem>>( await resposta.Content.ReadAsStringAsync());

            }

            return lista;
        }

        public static async Task<bool> insertMensagem(Mensagem mensagem) {


            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("id_chat",mensagem.id_chat.ToString()),
            new KeyValuePair<string,string>("id_usuario",mensagem.id_usuario.ToString()),
            new KeyValuePair<string,string>("mensagem",mensagem.mensagem)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.PostAsync(url + "chat/" + mensagem.id_chat + "/msg", parametros);
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }

        public static async Task<bool> deleteMensagem(Mensagem mensagem) {

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = await requisicao.DeleteAsync(url + "chat/" + mensagem.id_chat + "/delete/" + mensagem.id);
            if (resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            }

            return false;
        }


    }
}
