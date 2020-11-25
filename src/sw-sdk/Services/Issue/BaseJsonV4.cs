using SW.Helpers;
using SW.Services.Stamp;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Issue
{
    public abstract class BaseStampJsonV4 : IssueService
    {
        private string _operation;
        public BaseStampJsonV4(string url, string user, string password, string operation, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        public BaseStampJsonV4(string url, string token, string operation, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        public virtual async Task<StampResponseV1> TimbrarJsonV1Async(string json, string email = null, string customId = null)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                var headers = await GetHeadersAsync(email, customId);
                headers.Add("email", email);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/jsontoxml");
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v1.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual async Task<StampResponseV2> TimbrarJsonV2Async(string json, string email = null, string customId = null)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2();
            try
            {
                var headers = await GetHeadersAsync(email, customId);
                headers.Add("email", email);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/jsontoxml");
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v2.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual async Task<StampResponseV3> TimbrarJsonV3Async(string json, string email = null, string customId = null)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3();
            try
            {
                var headers = await GetHeadersAsync(email, customId);
                headers.Add("email", email);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/jsontoxml");
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v3.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual async Task<StampResponseV4> TimbrarJsonV4Async(string json, string email = null, string customId = null)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
            try
            {
                var headers = await GetHeadersAsync(email, customId);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/jsontoxml");
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v4.ToString(),
                                ""), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
