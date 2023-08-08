using SW.Handlers;
using SW.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.Relations
{
    public class Relations : RelationsService
    {
        private readonly ResponseHandler<RelationsResponse> _handler;
        /// <summary>
        /// Crear una instancia de la clase Relations.
        /// </summary>
        /// <remarks>Incluye métodos para la consulta de comprobantes relacionados.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Relations(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<RelationsResponse>();
        }
        /// <summary>
        /// Crear una instancia de la clase Relations.
        /// </summary>
        /// <remarks>Incluye métodos para la consulta de comprobantes relacionados.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Relations(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<RelationsResponse>();
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(string cer, string key, string rfc, string password, string uuid)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = this.RequestRelations(cer, key, rfc, password, uuid);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "relations/csd", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(byte[] xmlCancelation)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = this.RequestRelations(xmlCancelation);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "relations/xml", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(string pfx, string rfc, string password, string uuid)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = this.RequestRelations(pfx, rfc, password, uuid);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "relations/pfx", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(string rfc, string uuid)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestRelationsAsync(rfc, uuid);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Post;
                var headers = await GetHeadersAsync();
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url, headers, $"relations/{rfc}/{uuid}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        /// <summary>
        /// Servicio de consulta de comprobantes relacionados por CSD.
        /// </summary>
        /// <param name="cer">Certificado CSD del emisor en base 64.</param>
        /// <param name="key">Key del certificado en base 64.</param>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <param name="uuid">Folio fiscal del comprobante a consultar.</param>
        /// <returns></returns>
        public async Task<RelationsResponse> RelationsByCSDAsync(string cer, string key, string rfc, string password, string uuid)
        {
            return await RelationsRequestAsync(cer, key, rfc, password, uuid);
        }
        /// <summary>
        /// Servicio de consulta de comprobantes relacionados por CSD.
        /// </summary>
        /// <param name="xmlCancelation">XML de consulta de relacionados.</param>
        /// <returns></returns>
        public async Task<RelationsResponse> RelationsByXMLAsync(byte[] xmlCancelation)
        {
            return await RelationsRequestAsync(xmlCancelation);
        }
        /// <summary>
        /// Servicio de consulta de comprobantes relacionados por PFX.
        /// </summary>
        /// <param name="pfx">Certificados en formato PFX.</param>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="password">Contraseña del PFX.</param>
        /// <param name="uuid">Folio fiscal del comprobante a consultar.</param>
        /// <returns></returns>
        public async Task<RelationsResponse> RelationsByPFXAsync(string pfx, string rfc, string password, string uuid)
        {
            return await RelationsRequestAsync(pfx, rfc, password, uuid);
        }
        /// <summary>
        /// Servicio de consulta de comprobantes relacionados por UUID.
        /// </summary>
        /// <param name="rfc">RFC del emisor.</param>
        /// <param name="uuid">Folio fiscal del comprobante a consultar.</param>
        /// <returns></returns>
        public async Task<RelationsResponse> RelationsByRfcUuidAsync(string rfc, string uuid)
        {
            return await RelationsRequestAsync(rfc, uuid);
        }
    }
}
