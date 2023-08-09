using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Relations
{
    public abstract class RelationsService : Services
    {
        protected RelationsService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected RelationsService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal abstract Task<RelationsResponse> RelationsRequestAsync(string cer, string key, string rfc, string password, string uuid);
        internal abstract Task<RelationsResponse> RelationsRequestAsync(byte[] xmlCancelation);
        internal abstract Task<RelationsResponse> RelationsRequestAsync(string pfx, string rfc, string password, string uuid);
        internal abstract Task<RelationsResponse> RelationsRequestAsync(string rfc, string uuid);
        internal StringContent RequestRelations(string cer, string key, string rfc, string password, string uuid)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new RelationsRequestCSD()
            {
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
        internal MultipartFormDataContent RequestRelations(byte[] xmlCancelation)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            ByteArrayContent fileContent = new ByteArrayContent(xmlCancelation);
            content.Add(fileContent, "xml", "xml");
            return content;
        }
        internal StringContent RequestRelations(string pfx, string rfc, string password, string uuid)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new RelationsRequestPFX()
            {
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
        internal virtual async Task<HttpWebRequest> RequestRelationsAsync(string rfc, string uuid)
        {
            await this.SetupRequestAsync();
            string path = $"relations/{rfc}/{uuid}";
            var request = (HttpWebRequest)WebRequest.Create(this.Url + path);
            request.ContentType = "application/json";
            request.ContentLength = 0;
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add(Helpers.RequestHelper.GetHeadersAsync(this).ToString());
            Helpers.RequestHelper.SetupProxy(this.Proxy, this.ProxyPort, ref request);
            return request;
        }
    }
}
