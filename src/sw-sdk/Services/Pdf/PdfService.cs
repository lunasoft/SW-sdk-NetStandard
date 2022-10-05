using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Pdf
{
    public abstract class PdfService : Services
    {
        protected PdfService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected PdfService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal virtual StringContent GetStringContent(string xml, string b64Logo, string templateId, Dictionary<string, string> ObservacionesAdicionales, bool isB64)
        {
            var request = new PdfRequest();
            request.xmlContent = isB64 ? Encoding.UTF8.GetString(Convert.FromBase64String(xml)) : xml;
            request.extras = ObservacionesAdicionales;
            request.logo = b64Logo;
            request.templateId = templateId;
            var content = new StringContent(JsonConvert.SerializeObject(
                request, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }),
            Encoding.UTF8, "application/json");
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
