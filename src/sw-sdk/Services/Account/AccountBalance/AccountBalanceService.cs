using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using SW.Helpers;
using SW.Entities;
using sw_sdk.Services.Account.AccountBalance;

namespace SW.Services.Account.AccountBalance
{
    public abstract class AccountBalanceService : Services
    {
        /// <summary>
        /// Sobrecarga que recibe usuario y contraseña
        /// </summary>
        /// <param name="urlApi">URL de la API que se usará</param>
        /// <param name="url">URL Services que realiza la autenticación</param>
        /// <param name="user">Correo del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>
        protected AccountBalanceService(string urlApi, string url, string user, string password, string proxy, int proxyPort) : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Sobrecarga que recibe token
        /// </summary>
        /// <param name="url">URL de la API que se usará</param>
        /// <param name="token">Token de la cuenta del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>
        protected AccountBalanceService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Metodo que muestra el balance de timbres de un usuario
        /// </summary>
        /// <returns>Regresa un objeto Response</returns>
        internal abstract Task<BalanceResponse> GetBalance();
        /// <summary>
        /// Metodo para añadir y eliminar timbres a una cuenta hijo desde la cuenta dealer
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le asignaran los timbres</param>
        /// <param name="stamps">Cantidad de timbres a agregar</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns>Retorna un objeto handler</returns>
        internal async Task<AccountBalanceResponse> StampsDistribution(Guid idUser, int stamps, ActionsAccountBalance action, string comment)
        {
            var handler = new AccountBalanceResponseHandler();
            var headers = await RequestHelper.GetHeadersAsync(this);
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            var path = String.Format("{0}/{1}/{2}", "management/v2/api/dealers/users", idUser, "stamps");
            var content = GetStringContent(comment, stamps);
            return await handler.SendRequestBalanceAsync(action, this.UrlApi ?? this.Url, headers, path, content, proxy);
        }
        /// <summary>
        /// Metodo que serializa el comentario a json y agrega los headers Content-Type, Content-Length
        /// </summary>
        /// <param name="comment">Comentario del movimiento en string </param>
        /// <param name="stamps">Número de tmbres a remover o agregar </param>
        /// <returns></returns>
        private StringContent GetStringContent(string comment, int stamps)
        {
            var request = new AccountBalanceRequest();
            request.Comment = comment;
            request.Stamps = stamps;
            var content = new StringContent(JsonConvert.SerializeObject(
                request, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }),
            Encoding.UTF8, "application/json");
            return content;
        }
    }
}