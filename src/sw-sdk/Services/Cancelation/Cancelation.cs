using System;
using SW.Helpers;
using System.Net;
using System.Threading.Tasks;
using SW.Handlers;

namespace SW.Services.Cancelation
{
    public class Cancelation : CancelationService
    {
        private readonly ResponseHandler<CancelationResponse> _handler;
        /// <summary>
        /// Crear una instancia de la clase Cancelation.
        /// </summary>
        /// <remarks>Incluye métodos para realizar cancelaciones de CFDI.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Cancelation(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<CancelationResponse>();
        }
        /// <summary>
        /// Crear una instancia de la clase Cancelation.
        /// </summary>
        /// <remarks>Incluye métodos para realizar cancelaciones de CFDI.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Cancelation(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<CancelationResponse>();
        }
        internal override async Task<CancelationResponse> Cancelar(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                await this.SetupRequestAsync();
                var headers = Helpers.RequestHelper.GetHeaders(this.Token);
                var content = this.RequestCancelar(cer, key, rfc, password, uuid, motivo, folioSustitucion);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "cfdi33/cancel/csd", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<CancelationResponse> Cancelar(string rfc, string uuid, string motivo, string folioSustitucion)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestCancelarAsync(rfc, uuid, motivo, folioSustitucion);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Post;
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                await this.SetupRequestAsync();
                var headers = Helpers.RequestHelper.GetHeaders(this.Token);
                return await _handler.GetPostResponseAsync(this.Url, headers, $"cfdi33/cancel/{rfc}/{uuid}/{motivo}/{folioSustitucion}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<CancelationResponse> Cancelar(byte[] xmlCancelation)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                await this.SetupRequestAsync();
                var headers = Helpers.RequestHelper.GetHeaders(this.Token);
                var content = await this.RequestCancelarFileAsync(xmlCancelation);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "cfdi33/cancel/xml", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<CancelationResponse> Cancelar(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                await this.SetupRequestAsync();
                var headers = Helpers.RequestHelper.GetHeaders(this.Token);
                var content = this.RequestCancelar(pfx, rfc, password, uuid, motivo, folioSustitucion);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "cfdi33/cancel/pfx", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        /// <summary>
        /// Servicio de cancelación por CSD.
        /// </summary>
        /// <param name="cer">Certificado CSD del emisor en formato B64.</param>
        /// <param name="key">Key del certificado del emisor en formato B64.</param>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <param name="uuid">Folio fiscal del comprobante a cancelar.</param>
        /// <param name="motivo">Motivo de cancelación.</param>
        /// <param name="folioSustitucion">Folio fiscal del comprobante que sustituye.</param>
        /// <returns><see cref="CancelationResponse"/></returns>
        public Task<CancelationResponse> CancelarByCSDAsync(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion = null)
        {
            return Cancelar(cer, key, rfc, password, uuid, motivo, folioSustitucion);
        }
        /// <summary>
        /// Servicio de cancelación por XML.
        /// </summary>
        /// <param name="xmlCancelation">XML de cancelación.</param>
        /// <returns><see cref="CancelationResponse"/></returns>
        public Task<CancelationResponse> CancelarByXMLAsync(byte[] xmlCancelation)
        {
            return Cancelar(xmlCancelation);
        }
        /// <summary>
        /// Servicio de cancelación por PFX.
        /// </summary>
        /// <param name="pfx">Certificados en formato PFX.</param>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="password">Contraseña del PFX.</param>
        /// <param name="uuid">Folio fiscal del comprobante a cancelar.</param>
        /// <param name="motivo">Motivo de cancelación.</param>
        /// <param name="folioSustitucion">Folio fiscal del comprobante que sustituye.</param>
        /// <returns><see cref="CancelationResponse"/></returns>
        public Task<CancelationResponse> CancelarByPFXAsync(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion = null)
        {
            return Cancelar(pfx, rfc, password, uuid, motivo, folioSustitucion);
        }
        /// <summary>
        /// Servicio de cancelación por UUID.
        /// </summary>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="uuid">Folio fiscal del comprobante a cancelar.</param>
        /// <param name="motivo">Motivo de cancelación.</param>
        /// <param name="folioSustitucion">Folio fiscal del comprobante que sustituye.</param>
        /// <returns><see cref="CancelationResponse"/></returns>
        public Task<CancelationResponse> CancelarByRfcUuidAsync(string rfc, string uuid, string motivo, string folioSustitucion = null)
        {
            return Cancelar(rfc, uuid, motivo, folioSustitucion);
        }
    }
}
