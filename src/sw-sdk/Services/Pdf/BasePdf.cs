using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SW.Services.Pdf
{
    public abstract class BasePdf : PdfService
    {
        private string _operation;
        private string _apiUrl;
        public BasePdf(string url, string urlApi, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _apiUrl = urlApi;
            _operation = operation;
        }
        public BasePdf(string url, string urlApi, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _apiUrl = urlApi;
            _operation = operation;
        }
        public virtual async Task<PdfResponse> GenerarPdfAsync(string xml, string templateId, Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {
            PdfResponseHandler handler = new PdfResponseHandler();
            try
            {
                string format = isB64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                headers.Add("templateId", templateId);
                var request = new PdfRequest();
                request.xmlContent = xml;
                request.extras = ObservacionesAdicionales;
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(_apiUrl,
                                string.Format("/pdf/v1/generate",
                                _operation), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }

        }
    }
}
