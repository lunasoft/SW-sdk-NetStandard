using SW.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.Pendings
{
    public class Pending : PendingsService
    {
        PendingsResponseHandler _handler;
        public Pending(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new PendingsResponseHandler();
        }
        public Pending(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new PendingsResponseHandler();
        }
        internal override async Task<PendingsResponse> PendingsRequestAsync(string rfc)
        {
            PendingsResponseHandler handler = new PendingsResponseHandler();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestPendingsAsync(rfc);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Get;
                var headers = await GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetResponseAsync(this.Url, headers, $"pendings/{rfc}", proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        public async Task<PendingsResponse> PendingsByRfcAsync(string rfc)
        {
            return await PendingsRequestAsync(rfc);
        }
    }
}
