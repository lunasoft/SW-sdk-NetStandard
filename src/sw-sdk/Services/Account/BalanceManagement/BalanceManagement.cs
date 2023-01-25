using System;
using SW.Helpers;
using SW.Entities;
using System.Threading.Tasks;
using SW.Handlers;
using System.Net.Http;
using System.Text;
using System.Net;
using sw_sdk.Services.Account.BalanceManagement;
using Newtonsoft.Json;

namespace SW.Services.Account.BalanceManagement
{
    public class BalanceManagement : BalanceManagementService
    {
        //Atributo que nos ayudara con las respuestas del servicio
        //private readonly ResponseHandler<BalanceManagementResponse> _handler;
      //  private readonly ResponseHandler<BalanceManagementResponse> _handler;
        /// <summary>
        /// Balance Management que requiere de usuario y contraseña
        /// </summary>
        /// <param name="urlApi">URL de la API que se usará</param>
        /// <param name="url">URL Services que realiza la autenticación</param>
        /// <param name="user">Correo del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>
        public BalanceManagement(string urlApi,string url, string user, string password, int proxyPort = 0, string proxy = null) : base(urlApi, url, user, password, proxy, proxyPort)
        {
           // _handler = new ResponseHandler<BalanceResponse>();
        }
        /// <summary>
        /// Balance Management que recibe el token para mostrar los datos
        /// </summary>
        /// <param name="url">URL de la API que se usará</param>
        /// <param name="token">Token de la cuenta del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>

        public BalanceManagement(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
           // _handler = new ResponseHandler<BalanceResponse>();
        }
        /// <summary>
        /// Metodo que obtiene el balance de timbres del usuario
        /// </summary>
        /// <param name="idUser">ID del usuario a consultar timbres</param>
        /// <returns>Retorna un objeto handler</returns>
        internal async override Task<BalanceResponse> GetBalanceID(Guid idUser)
        {
            ResponseHandler<BalanceResponse> handler = new ResponseHandler<BalanceResponse>();
            try
            {
               
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                BalanceResponse response= await handler.GetResponseAsync("https://api.test.sw.com.mx/", headers, "management/api/balance/" + idUser.ToString(), proxy);
                return response;
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        public async Task<BalanceResponse> ConsultarSaldoAsync(Guid idUser)
        {
            return await GetBalanceID(idUser);
        }

        /// <summary>
        /// Metodo para añadir timbres a una cuenta hijo desde la cuenta dealer
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le asignaran los timbres</param>
        /// <param name="stamps">Cantidad de timbres a agregar</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns>Retorna un objeto handler</returns>
        internal async override Task<BalanceManagementResponse> AddStamps(Guid idUser, int stamps, string comment)
        {
            ResponseHandler<BalanceManagementResponse> handler = new ResponseHandler<BalanceManagementResponse>();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = GetStringContent(comment);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.UrlApi, "management/api/balance/"+idUser+"/add/"+stamps, headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }

        }
        public async Task<BalanceManagementResponse> AgregarTimbresAsync(Guid idUser, int stamps, string comment)
        {
            return await AddStamps(idUser, stamps, comment);
        }

        /// <summary>
        /// Metodo para eliminar timbres de una cuenta hijo desde la cuenta dealer
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le eliminaran los timbres</param>
        /// <param name="stamps">Cantidad de timbres a agregar</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns>Retorna un objeto handler</returns>
        internal async override Task<BalanceManagementResponse> RemoveStamps(Guid idUser, int stamps, string comment)
        {
            ResponseHandler<BalanceManagementResponse> handler = new ResponseHandler<BalanceManagementResponse>();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = GetStringContent(comment);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.UrlApi, "management/api/balance/" + idUser + "/remove/" + stamps, headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }

        public async Task<BalanceManagementResponse> EliminarTimbresAsync(Guid idUser, int stamps, string comment)
        {
            return await RemoveStamps(idUser, stamps, comment);
        }

        /// <summary>
        /// Metodo que serializa el comentario a json y agrega los headers Content-Type, Content-Length
        /// </summary>
        /// <param name="comment">Comentario del movimiento en string </param>
        /// <returns></returns>
        internal virtual StringContent GetStringContent(string comment)
        {
            var request = new BalanceManagementRequest();
            request.comment = comment;
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
