using SW.Handlers;
using SW.Helpers;
using SW.Services.Cancelation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.CancelationRetention
{
    public class CancelationRetention : CancelationRetentionService
    {
        private readonly ResponseHandler<CancelationResponse> _handler;

        /// <summary>
        /// Crear una instancia de la clase CancelationRetention.
        /// </summary>
        /// <remarks>Incluye métodos para realizar cancelaciones de CFDI de retenciones.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public CancelationRetention(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<CancelationResponse>();
        }
        /// <summary>
        /// Crear una instancia de la clase CancelationRetention.
        /// </summary>
        /// <remarks>Incluye métodos para realizar cancelaciones de CFDI de retenciones.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public CancelationRetention(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<CancelationResponse>();
        }

        internal override async Task<CancelationResponse> CancelarRetention(byte[] xmlCancelation)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await RequestHelper.GetHeadersAsync(this);
                var content = await this.RequestCancelarRetentionFileAsync(xmlCancelation);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "retencion/cancel/xml", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<CancelationResponse> CancelarRetention(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await RequestHelper.GetHeadersAsync(this);
                var content = this.RequestCancelarRetention(cer, key, rfc, password, uuid, motivo, folioSustitucion);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "retencion/cancel/csd", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<CancelationResponse> CancelarRetention(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await RequestHelper.GetHeadersAsync(this);
                var content = this.RequestCancelarRetention(pfx, rfc, password, uuid, motivo, folioSustitucion);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "retencion/cancel/pfx", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        /// <summary>
        /// Servicio de cancelación de retenciones por XML.
        /// </summary>
        /// <param name="xmlCancelation">XML de cancelación de retenciones.</param>
        /// <returns><see cref="CancelationResponse"/></returns>
        public Task<CancelationResponse> CancelarUnoAsync(byte[] xmlCancelation)
        {
            return CancelarRetention(xmlCancelation);
        }

        /// <summary>
        /// Servicio de cancelación de retenciones utilizando el certificado CSD.
        /// </summary>
        /// <param name="cer">Certificado CSD del emisor en formato B64.</param>
        /// <param name="key">Key del certificado del emisor en formato B64.</param>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <param name="uuid">Folio fiscal del comprobante a cancelar.</param>
        /// <param name="motivo">Motivo de cancelación.</param>
        /// <param name="folioSustitucion">Folio fiscal del comprobante que sustituye.</param>
        /// <returns><see cref="CancelationResponse"/></returns>
        public Task<CancelationResponse> CancelarUnoCsdAsync(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion = null)
        {
            return CancelarRetention(cer, key, rfc, password, uuid, motivo, folioSustitucion);
        }

        /// <summary>
        /// Servicio de cancelación de retenciones utilizando un PFX.
        /// </summary>
        /// <param name="pfx">Certificados en formato PFX.</param>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="password">Contraseña del PFX.</param>
        /// <param name="uuid">Folio fiscal del comprobante a cancelar.</param>
        /// <param name="motivo">Motivo de cancelación.</param>
        /// <param name="folioSustitucion">Folio fiscal del comprobante que sustituye.</param>
        /// <returns><see cref="CancelationResponse"/></returns>
        public Task<CancelationResponse> CancelarUnoPfxAsync(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion = null)
        {
            return CancelarRetention(pfx, rfc, password, uuid, motivo, folioSustitucion);
        }
    }
}
