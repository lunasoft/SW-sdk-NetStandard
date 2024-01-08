using SW.Handlers;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Taxpayer
{
    public abstract class TaxpayerService : Services
    {
        private readonly ResponseHandler<TaxpayerResponse> _handler;

        /// <summary>
        /// Sobrecarga que recibe usuario y contraseña
        /// </summary>
        /// <param name="url">URL Services que realiza la autenticación</param>
        /// <param name="user">Correo del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy</param>
        protected TaxpayerService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<TaxpayerResponse>();
        }
        /// <summary>
        /// Sobrecarga que recibe token
        /// </summary>
        /// <param name="url">URL Services</param>
        /// <param name="token">Token de la cuenta del usuario</param>
        /// <param name="proxyPort">Puerto proxy</param>
        /// <param name="proxy">Proxy</param>
        protected TaxpayerService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<TaxpayerResponse>();
        }

        /// <summary>
        /// Servicio asincrónico para consultar información de un contribuyente mediante su RFC dentro de la lista 69 B.
        /// </summary>
        /// <param name="rfc">RFC del contribuyente a consultar.</param>
        /// <returns>Respuesta del contribuyente encapsulada en <see cref="TaxpayerResponse"/>.</returns>
        internal async Task<TaxpayerResponse> TaxpayerServiceAsync(string rfc)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url, headers, $"taxpayers/{rfc}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
    }
}
