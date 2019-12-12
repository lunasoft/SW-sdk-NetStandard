using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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

        internal virtual MultipartFormDataContent GetMultipartContent(byte[] xml, Dictionary<string, string> ObservacionesAdcionales)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            ByteArrayContent fileContent = new ByteArrayContent(xml);
            content.Add(fileContent, "xml", "xml");
            content.Add(new StringContent(JsonConvert.SerializeObject(ObservacionesAdcionales, Formatting.Indented)), "extras");
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
