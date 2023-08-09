using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.Pendings
{
    public abstract class PendingsService : Services
    {
        protected PendingsService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected PendingsService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal abstract Task<PendingsResponse> PendingsRequestAsync(string rfc);
        internal async Task<HttpWebRequest> RequestPendingsAsync(string rfc)
        {
            await this.SetupRequestAsync();
            string path = $"pendings/{rfc}";
            var request = (HttpWebRequest)WebRequest.Create(this.Url + path);
            request.ContentType = "application/json";
            request.ContentLength = 0;
            request.Method = WebRequestMethods.Http.Get;
            request.Headers.Add(Helpers.RequestHelper.GetHeadersAsync(this).ToString());
            Helpers.RequestHelper.SetupProxy(this.Proxy, this.ProxyPort, ref request);
            return request;
        }
    }
}
