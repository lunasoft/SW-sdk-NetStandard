using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
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
                Foliosustitucion = folioSustitucion,
                Motivo = motivo,
                B64Cer = cer,
                B64Key = key,
                Password = password,
                Rfc = rfc,
                Uuid = uuid
            }, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
           StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }
        internal virtual StringContent RequestCancelar(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new CancelationRequestPFX()
            {
                Foliosustitucion = folioSustitucion,
                Motivo = motivo,
                B64Pfx = pfx,
                Password = password,
                Rfc = rfc,
                Uuid = uuid
            }, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
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
