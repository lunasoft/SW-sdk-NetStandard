using SW.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class BaseStampV2 : StampService
    {
        private string _operation;
        protected BaseStampV2(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        protected BaseStampV2(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV1"/></returns>
        public virtual async Task<StampResponseV1> TimbrarV1Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/v2/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V1.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV2"/></returns>
        public virtual async Task<StampResponseV2> TimbrarV2Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/v2/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V2.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV3"/></returns>
        public virtual async Task<StampResponseV3> TimbrarV3Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/v2/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V3.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV4"/></returns>
        public virtual async Task<StampResponseV4> TimbrarV4Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/v2/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V4.ToString(),
                                format), headers, content,proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
