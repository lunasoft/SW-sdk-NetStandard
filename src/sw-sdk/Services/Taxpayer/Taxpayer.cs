using SW.Handlers;
using SW.Helpers;
using SW.Services.Pendings;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Taxpayer
{
    public class Taxpayer : TaxpayerService
    {
        private readonly ResponseHandler<TaxpayerResponse> _handler;
        public Taxpayer(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<TaxpayerResponse>();
        }
        public Taxpayer(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort) 
        {
            _handler = new ResponseHandler<TaxpayerResponse>();
        }
        internal override async Task<TaxpayerResponse> TaxpayerRequestAsync(string rfc) 
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestTaxpayerAsync(rfc);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Get;
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url, headers, $"taxpayers/{rfc}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        public async Task<TaxpayerResponse> GetTaxpayer (string rfc)
        {
            return await TaxpayerRequestAsync(rfc);
        }
    }
}
