using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Cancelation
{
    public abstract class CancelationService : Services
    {
        protected CancelationService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected CancelationService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal abstract Task<CancelationResponse> Cancelar(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion);
        internal abstract Task<CancelationResponse> Cancelar(byte[] xmlCancelation);
        internal abstract Task<CancelationResponse> Cancelar(string rfc, string uuid, string motivo, string folioSustitucion);
        internal abstract Task<CancelationResponse> Cancelar(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion);
        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            return headers;
        }
        internal virtual async Task<HttpWebRequest> RequestCancelarAsync(string rfc, string uuid, string motivo, string folioSustitucion)
        {
            await this.SetupRequestAsync();
            string path = string.Format("cfdi33/cancel/{0}/{1}/{2}/{3}",rfc, uuid, motivo, folioSustitucion);
            var request = (HttpWebRequest)WebRequest.Create(this.Url + path);
            request.ContentType = "application/json";
            request.ContentLength = 0;
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add(HttpRequestHeader.Authorization.ToString(), "bearer " + this.Token);
            Helpers.RequestHelper.SetupProxy(this.Proxy, this.ProxyPort, ref request);
            return request;
        }
        internal virtual StringContent RequestCancelar(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new CancelationRequestCSD()
            {
                _folioSustitucion = folioSustitucion,
                _motivo = motivo,
                _b64Cer = cer,
                _b64Key = key,
                _password = password,
                _rfc = rfc,
                _uuid = uuid
            });
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }
        internal virtual StringContent RequestCancelar(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new CancelationRequestPFX()
            {
                _folioSustitucion = folioSustitucion,
                _motivo = motivo,
                _b64Pfx = pfx,
                _password = password,
                _rfc = rfc,
                _uuid = uuid
            });
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }
        internal virtual async Task<MultipartFormDataContent> RequestCancelarFileAsync(byte[] xmlCancelation)
        {
            await this.SetupRequestAsync();
            MultipartFormDataContent content = new MultipartFormDataContent();
            ByteArrayContent fileContent = new ByteArrayContent(xmlCancelation);
            content.Add(fileContent, "xml", "xml");
            return content;
        }
    }
}
