using Newtonsoft.Json;
using SW.Handlers;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Resend
{
    public abstract class ResendService : Services
    {
        private readonly ResponseHandler<ResendResponse> _handler;
        protected ResendService(string urlApi, string url, string user, string password, string proxy, int proxyPort) : base(urlApi, url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<ResendResponse>();
        }
        protected ResendService(string urlApi, string token, string proxy, int proxyPort) : base(urlApi, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<ResendResponse>();
        }
        internal async Task<ResendResponse> ResendEmailServiceAsync(Guid uuid, string[] email)
        {
            try
            {
                Validation.ValidateEmail(email);
                var headers = await GetHeadersAsync();
                var request = new ResendRequest()
                {
                    uuid = uuid.ToString(),
                    to = String.Join(",", email)
                };
                var content = new StringContent(JsonConvert.SerializeObject(
                    request, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }),
                Encoding.UTF8, "application/json");
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(UrlApi ?? Url,
                                string.Format("/comprobante/resendemail"), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        private async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "Bearer " + this.Token }
                };
            return headers;
        }
    }
}
