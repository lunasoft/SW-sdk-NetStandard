using System;
using SW.Helpers;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.AcceptReject
{
    public class AcceptReject : AcceptRejectService
    {

        AcceptRejectResponseHandler _handler;
        public AcceptReject(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new AcceptRejectResponseHandler();
        }
        public AcceptReject(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new AcceptRejectResponseHandler();
        }
        internal async override Task<AcceptRejectResponse> AcceptRejectRequest(string cer, string key, string rfc, string password, AceptacionRechazoItem[] uuids)
        {
            AcceptRejectResponseHandler handler = new AcceptRejectResponseHandler();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var content = this.RequestAcceptReject(cer, key, rfc, password, uuids);
                return await handler.GetPostResponseAsync(this.Url,
                                "acceptreject/csd", await headers, content, proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        internal async override Task<AcceptRejectResponse> AcceptRejectRequest(byte[] xmlCancelation)
        {
            AcceptRejectResponseHandler handler = new AcceptRejectResponseHandler();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var content = this.RequestAcceptReject(xmlCancelation);
                return await handler.GetPostResponseAsync(this.Url,
                                "acceptreject/xml", await headers, content, proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        internal async override Task<AcceptRejectResponse> AcceptRejectRequest(string pfx, string rfc, string password, AceptacionRechazoItem[] uuid)
        {
            AcceptRejectResponseHandler handler = new AcceptRejectResponseHandler();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var content = this.RequestAcceptReject(pfx, rfc, password, uuid);
                return await handler.GetPostResponseAsync(this.Url,
                                "acceptreject/pfx", await headers, content, proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        internal async override Task<AcceptRejectResponse> AcceptRejectRequest(string rfc, string uuid, EnumAcceptReject enumAcceptReject)
        {
            AcceptRejectResponseHandler handler = new AcceptRejectResponseHandler();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestAcceptRejectAsync(rfc, uuid, enumAcceptReject);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Post;
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url, await headers, $"acceptreject/{rfc}/{uuid}/{enumAcceptReject.ToString()}", proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }

        /// <summary>
        /// Servicio de aceptación o rechazo por CSD de comprobantes pendientes de cancelación.
        /// </summary>
        /// <param name="cer">Certificado CSD en B64.</param>
        /// <param name="key">Certificado Key en B64.</param>
        /// <param name="rfc">RFC del receptor.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <param name="uuids">Folios a aceptar o rechazar.</param>
        /// <returns></returns>
        public async Task<AcceptRejectResponse> AcceptByCSD(string cer, string key, string rfc, string password, AceptacionRechazoItem[] uuids)
        {
            return await AcceptRejectRequest(cer, key, rfc, password, uuids);
        }
        /// <summary>
        /// Servicio de aceptación o rechazo por XML de comprobantes pendientes de cancelación.
        /// </summary>
        /// <param name="xmlCancelation">XML de aceptación o rechazo.</param>
        /// <returns></returns>
        public async Task<AcceptRejectResponse> AcceptByXML(byte[] xmlCancelation)
        {
            return await AcceptRejectRequest(xmlCancelation);
        }
        /// <summary>
        /// Servicio de aceptación o rechazo por PFX de comprobantes pendientes de cancelación.
        /// </summary>
        /// <param name="pfx">Certificado PFX en B64.</param>
        /// <param name="rfc">RFC del receptor.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <param name="uuid">Folios a aceptar o rechazar.</param>
        /// <returns></returns>
        public async Task<AcceptRejectResponse> AcceptByPFX(string pfx, string rfc, string password, AceptacionRechazoItem[] uuid)
        {
            return await AcceptRejectRequest(pfx, rfc, password, uuid);
        }
        /// <summary>
        /// Servicio de aceptación o rechazo por UUID de comprobantes pendientes de cancelación.
        /// </summary>
        /// <param name="rfc">RFC del receptor.</param>
        /// <param name="uuid">Folio a aceptar o rechazar.</param>
        /// <param name="enumAcceptReject">Especifica aceptación o rechazo.</param>
        /// <returns></returns>
        public async Task<AcceptRejectResponse> AcceptByRfcUuid(string rfc, string uuid, EnumAcceptReject enumAcceptReject)
        {
            return await AcceptRejectRequest(rfc, uuid, enumAcceptReject);
        }
    }
}
