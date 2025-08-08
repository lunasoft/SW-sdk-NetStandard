using SW.Handlers;
using SW.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.StampRetention
{
    public abstract class BaseStampRetention : StampRetentionService
    {
        private string _operation;
        protected BaseStampRetention(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        protected BaseStampRetention(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }

        /// <summary>
        /// Servicio de timbrado de un CFDI de retenciones previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampRetentionResponseV3"/></returns>
        public virtual async Task<StampRetentionResponseV3> TimbrarV3Async(string xml, bool isb64 = false)
        {
            ResponseHandler<StampRetentionResponseV3> handler  = new ResponseHandler<StampRetentionResponseV3>();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("retencion/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V3.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
