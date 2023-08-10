using SW.Handlers;
using SW.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.Pendings
{
    public class Pending : PendingsService
    {
        private readonly ResponseHandler<PendingsResponse> _handler;
        /// <summary>
        /// Crear una instancia de la clase Pending.
        /// </summary>
        /// <remarks>Incluye métodos para la consulta de cancelaciones pendientes de aceptación o rechazo.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pending(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<PendingsResponse>();
        }
        /// <summary>
        /// Crear una instancia de la clase Pending.
        /// </summary>
        /// <remarks>Incluye métodos para la consulta de cancelaciones pendientes de aceptación o rechazo.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pending(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<PendingsResponse>();
        }
        internal override async Task<PendingsResponse> PendingsRequestAsync(string rfc)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestPendingsAsync(rfc);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Get;
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url, headers, $"pendings/{rfc}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        /// <summary>
        /// Servicio de consulta de cancelaciones pendientes de aceptación o rechazo.
        /// </summary>
        /// <param name="rfc">RFC del receptor.</param>
        /// <returns><see cref="PendingsResponse"/></returns>
        public async Task<PendingsResponse> PendingsByRfcAsync(string rfc)
        {
            return await PendingsRequestAsync(rfc);
        }
    }
}
