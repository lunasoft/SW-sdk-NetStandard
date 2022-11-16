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
        /// This Service is Not Implemented
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public Cancelation(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<CancelationResponse>();
        }
        /// <summary>
        /// This Service is Not Implemented
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        public Cancelation(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<CancelationResponse>();
        }

        internal override async Task<CancelationResponse> Cancelar(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
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
                var headers = await GetHeadersAsync();
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
                var headers = await GetHeadersAsync();
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
                var headers = await GetHeadersAsync();
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
        public Task<CancelationResponse> CancelarByCSDAsync(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion = null)
        {
            return Cancelar(cer, key, rfc, password, uuid, motivo, folioSustitucion);
        }
        public Task<CancelationResponse> CancelarByXMLAsync(byte[] xmlCancelation)
        {
            return Cancelar(xmlCancelation);
        }
        public Task<CancelationResponse> CancelarByPFXAsync(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion = null)
        {
            return Cancelar(pfx, rfc, password, uuid, motivo, folioSustitucion);
        }
        public Task<CancelationResponse> CancelarByRfcUuidAsync(string rfc, string uuid, string motivo, string folioSustitucion = null)
        {
            return Cancelar(rfc, uuid, motivo, folioSustitucion);
        }
    }
}
