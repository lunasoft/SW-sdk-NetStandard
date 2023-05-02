using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using SW.Helpers;

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
        /// <param name="idUser">ID del usuario a consultar timbres</param>
        /// <returns>Regresa un objeto Response</returns>
        internal abstract Task<BalanceResponse> GetBalanceID(Guid idUser);
        /// <summary>
        /// Metodo para añadir y eliminar timbres a una cuenta hijo desde la cuenta dealer
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le asignaran los timbres</param>
        /// <param name="stamps">Cantidad de timbres a agregar</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns>Retorna un objeto handler</returns>
        internal abstract Task<AccountBalanceResponse> StampsDistribution(Guid idUser, int stamps, ActionsAccountBalance action, string comment);
        /// <summary>
        /// Metodo auxiliar para enviar los headers a la requests
        /// </summary>
        /// <returns>Un objeto Dictionary con los headers y sus valores</returns>
        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "Bearer " + this.Token }
                };
            return headers;
        }
        /// <summary>
        /// Metodo que serializa el comentario a json y agrega los headers Content-Type, Content-Length
        /// </summary>
        /// <param name="comment">Comentario del movimiento en string </param>
        /// <returns></returns>
        internal virtual StringContent GetStringContent(string comment)
        {
            var request = new AccountBalanceRequest();
            request.Comment = comment;
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