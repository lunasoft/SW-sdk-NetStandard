using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sw_sdk.Services.Resend
{
    public abstract class ResendService : SW.Services.Services
    {
        protected ResendService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected ResendService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal virtual MultipartFormDataContent GetMultipartContent(byte[] xml, Dictionary<string, string> ObservacionesAdcionales, string b64Logo)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            ByteArrayContent fileContent = new ByteArrayContent(xml);
            content.Add(fileContent, "file", "xml");
            content.Add(new StringContent(JsonConvert.SerializeObject(ObservacionesAdcionales, Formatting.None)), "extras");
            content.Add(new StringContent(b64Logo != null ? b64Logo : ""), "logo", "logo");
            return content;
        }
        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "Bearer " + this.Token }
                };
            return headers;
        }
    }
}
