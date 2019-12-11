using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Csd
{
    public abstract class CsdService : Services
    {
        protected CsdService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected CsdService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal abstract Task<UploadCsdResponse> UploadCsdAsync(string cer, string key, string password, string certificateType, bool isActive);
        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            return headers;
        }
        internal virtual async Task<StringContent> RequestCsdAsync(string cer, string key, string password, string certificateType, bool isActive)
        {
            await this.SetupRequestAsync();
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new UploadCsdRequest()
            {
                b64Cer = cer,
                b64Key = key,
                password = password,
                type = certificateType,
                is_active = isActive
            });
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }
    }
}
