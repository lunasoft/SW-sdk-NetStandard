using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SW.Services.Cancelation;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.CancelationRetention
{
    public abstract class CancelationRetentionService : Services
    {
        protected CancelationRetentionService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        { 
        }
        protected CancelationRetentionService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        { 
        }
        internal abstract Task<CancelationRetResponse> CancelarRetention(byte[] xmlCancelation);
        internal abstract Task<CancelationRetResponse> CancelarRetention(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion);
        internal abstract Task<CancelationRetResponse> CancelarRetention(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion);

        internal virtual StringContent RequestCancelarRetention(string cer, string key, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            var body = JsonConvert.SerializeObject(new CancelationRetRequestCSD()
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
        internal virtual StringContent RequestCancelarRetention(string pfx, string rfc, string password, string uuid, string motivo, string folioSustitucion)
        {
            var body = JsonConvert.SerializeObject(new CancelationRetRequestPFX()
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
        internal virtual async Task<MultipartFormDataContent> RequestCancelarRetentionFileAsync(byte[] xmlCancelation)
        {
            await this.SetupRequestAsync();
            MultipartFormDataContent content = new MultipartFormDataContent();
            ByteArrayContent fileContent = new ByteArrayContent(xmlCancelation);
            content.Add(fileContent, "xml", "xml");
            return content;
        }
    }
}
