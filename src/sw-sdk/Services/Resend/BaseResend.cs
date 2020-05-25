using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sw_sdk.Services.Resend
{
    public abstract partial class BaseResend : ResendService
    {
        private string _operation;
        private string _apiUrl;
        public BaseResend(string url, string urlApi, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _apiUrl = urlApi;
            _operation = operation;
        }
        public BaseResend(string url, string urlApi, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _apiUrl = urlApi;
            _operation = operation;
        }
        public virtual async Task<ResendResponse> ResendEmailAsync(string uuid, string to)
        {
            ResendResponseHandler handler = new ResendResponseHandler();
            try
            {
                var headers = await GetHeadersAsync();
                var request = new ResendRequest();
                request.uuid = uuid;
                request.to = to;
                var content = new StringContent(JsonConvert.SerializeObject(
                    request, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }),
                Encoding.UTF8, "application/json");
                var proxy = SW.Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(_apiUrl,
                                string.Format("/comprobante/resendemail",
                                _operation), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
