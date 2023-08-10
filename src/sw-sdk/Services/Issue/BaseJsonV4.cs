using SW.Handlers;
using SW.Helpers;
using SW.Services.Stamp;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Issue
{
    public abstract class BaseStampJsonV4 : IssueService
    {
        private string _operation;
        private readonly string _contentType;
        protected BaseStampJsonV4(string url, string user, string password, string operation, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
            _contentType = "application/jsontoxml";
        }
        protected BaseStampJsonV4(string url, string token, string operation, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
            _contentType = "application/jsontoxml";
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato JSON. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV1"/></returns>
        public virtual async Task<StampResponseV1> TimbrarJsonV1Async(string json, string email = null, string customId = null, string[] extras = null)
        {
            ResponseHandler<StampResponseV1> handler = new ResponseHandler<StampResponseV1>();
            try
            {
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue(_contentType);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V1.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato JSON. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV2"/></returns>
        public virtual async Task<StampResponseV2> TimbrarJsonV2Async(string json, string email = null, string customId = null, string[] extras = null)
        {
            ResponseHandler<StampResponseV2> handler = new ResponseHandler<StampResponseV2>();
            try
            {
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue(_contentType);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V2.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato JSON. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV3"/></returns>
        public virtual async Task<StampResponseV3> TimbrarJsonV3Async(string json, string email = null, string customId = null, string[] extras = null)
        {
            ResponseHandler<StampResponseV3> handler = new ResponseHandler<StampResponseV3>();
            try
            {
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue(_contentType);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V3.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato JSON. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV4"/></returns>
        public virtual async Task<StampResponseV4> TimbrarJsonV4Async(string json, string email = null, string customId = null, string[] extras = null)
        {
            ResponseHandler<StampResponseV4> handler = new ResponseHandler<StampResponseV4>();
            try
            {
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue(_contentType);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V4.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
