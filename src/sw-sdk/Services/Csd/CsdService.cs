using SW.Handlers;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Csd
{
    public abstract class CsdService : Services
    {
        protected CsdService(string url, string user, string password, string proxy, int proxyPort) 
            : base(url, user, password, proxy, proxyPort)
        {
        }
        protected CsdService(string url, string token, string proxy, int proxyPort) 
            : base(url, token, proxy, proxyPort)
        {
        }
        internal async Task<CsdResponse> UploadCsdServiceAsync(string cer, string key, string password)
        {
            ResponseHandler<CsdResponse> handler = new ResponseHandler<CsdResponse>();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                if (String.IsNullOrEmpty(cer) || String.IsNullOrEmpty(key))
                {
                    throw new ServicesException("El certificado o llave privada vienen vacios");
                }
                var headers = await GetHeadersAsync();
                var content = await this.RequestCsdAsync(cer, key, password);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                "certificates/save", headers, content, proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        internal async Task<CsdResponse> DeleteCsdServiceAsync(string noCertificado)
        {
            ResponseHandler<CsdResponse> handler = new ResponseHandler<CsdResponse>();
            new Validation(Url, User, Password, Token).ValidateHeaderParameters();
            if (String.IsNullOrEmpty(noCertificado))
            {
                throw new ServicesException("El numero de certificado viene vacio");
            }
            var headers = await GetHeadersAsync();
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            return await handler.DeleteResponseAsync(this.Url, headers, String.Format("certificates/{0}", noCertificado), proxy);
        }
        internal async Task<AllCsdResponse> GetAllCsdServiceAsync(string rfc = null)
        {
            ResponseHandler<AllCsdResponse> handler = new ResponseHandler<AllCsdResponse>();
            new Validation(Url, User, Password, Token).ValidateHeaderParameters();
            var headers = await GetHeadersAsync();
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            var path = rfc is null ? "certificates" : String.Format("certificates/rfc/{0}", rfc);
            return await handler.GetResponseAsync(this.Url, headers, path, proxy);
        }
        internal async Task<GetCsdResponse> GetCsdServiceAsync(string noCertificado)
        {
            ResponseHandler<GetCsdResponse> handler = new ResponseHandler<GetCsdResponse>();
            new Validation(Url, User, Password, Token).ValidateHeaderParameters();
            if (String.IsNullOrEmpty(noCertificado))
            {
                throw new ServicesException("El numero de certificado viene vacio");
            }
            var headers = await GetHeadersAsync();
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            return await handler.GetResponseAsync(this.Url, headers, String.Format("certificates/{0}", noCertificado), proxy);
        }
        private async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            return headers;
        }
        private async Task<StringContent> RequestCsdAsync(string cer, string key, string password)
        {
            await this.SetupRequestAsync();
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                b64Cer = cer,
                b64Key = key,
                password = password,
                type = "stamp",
                is_active = true
            });
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }
    }
}
