using SW.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class BaseStampV4 : StampService
    {
        private string _operation;
        public BaseStampV4(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        public BaseStampV4(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        public virtual async Task<StampResponseV1> TimbrarV1Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync(email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v1.ToString(),
                                format), headers, content, proxy);

            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual async Task<StampResponseV2> TimbrarV2Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync(email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v2.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual async Task<StampResponseV3> TimbrarV3Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync(email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v3.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual async Task<StampResponseV4> TimbrarV4Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync(email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v4.ToString(),
                                format), headers, content,proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
