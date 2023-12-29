using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Taxpayer
{
    public abstract class TaxpayerService : Services
    {
        protected TaxpayerService(string url, string username, string password, string proxy, int proxyPort) : base(url, username, password, proxy, proxyPort)
        {
        }
        protected TaxpayerService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal abstract Task<TaxpayerResponse> TaxpayerRequestAsync(string rfc);

        internal async Task<HttpWebRequest> RequestTaxpayerAsync(string rfc)
        {
            await this.SetupRequestAsync();
            string path = $"taxpayers/{rfc}";
            var request = (HttpWebRequest)WebRequest.Create(this.Url + path);
            request.ContentType = "application/json";
            request.ContentLength = 0;
            request.Method = WebRequestMethods.Http.Get;
            request.Headers.Add(HttpRequestHeader.Authorization.ToString(), "bearer " + this.Token);
            Helpers.RequestHelper.SetupProxy(this.Proxy, this.ProxyPort, ref request);
            return request;
        }
    }
}
