using SW.Handlers;
using SW.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.Pendings
{
    public class Pending : PendingsService
    {
        private readonly ResponseHandler<PendingsResponse> _handler;
        public Pending(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<PendingsResponse>();
        }
        public Pending(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<PendingsResponse>();
        }
        internal override async Task<PendingsResponse> PendingsRequestAsync(string rfc)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestPendingsAsync(rfc);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Get;
                var headers = await GetHeadersAsync();
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url, headers, $"pendings/{rfc}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        public async Task<PendingsResponse> PendingsByRfcAsync(string rfc)
        {
            return await PendingsRequestAsync(rfc);
        }
    }
}
