using App3_JWTAsync.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace App3_JWTAsync.Service {
    class JWTService {
        public const string Base_Url = "http://ws.spacedu.com.br/xf2018/rest/apix";

        private static string Token { get; set; }
        private static string TokenType { get; set; }

        public static object Httpclient { get; private set; }
        public static object JSonconverter { get; private set; }

        public async static Task<string> GetToken(string nome, string password) {
            var URL = Base_Url + "/token";

            HttpClient client = new HttpClient();
            var param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("nome", nome),
                new KeyValuePair<string, string>("password", password)
            });

            var resposta = await client.PostAsync(URL, param);

            if (resposta.StatusCode == HttpStatusCode.OK) {
                var respostaToken = JsonConvert.DeserializeObject<RespostaToken>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Token = respostaToken.access_token;
                TokenType = respostaToken.token_type;
                return TokenType + " - " + Token;
            } else {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        public async static Task<string> VerificarToken() {
            var URL = Base_Url + "/verify";

            HttpClient requisicao = new HttpClient();

            requisicao.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType, Token);
            var resposta = await requisicao.GetAsync(URL);

            if (resposta.StatusCode == HttpStatusCode.OK) {
                var respostaToken = JsonConvert.DeserializeObject<RespostaVerificar>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                return respostaToken.usuario.nome + " - " + respostaToken.usuario.id;
            } else {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }


        }

    }
}
