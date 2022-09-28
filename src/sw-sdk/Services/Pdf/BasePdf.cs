using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sw_sdk.Helpers;

namespace SW.Services.Pdf
{
    public abstract partial class BasePdf : PdfService
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
        internal virtual async Task<PdfResponse> GeneratePdfAsync(string xml, string b64Logo, PdfTemplates templateId, string idUser = null, string idDealer = null, Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {
            PdfResponseHandler handler = new PdfResponseHandler();
            try
            {
                var headers = await GetHeadersAsync();
                var request = new PdfRequest();
                if(!String.IsNullOrEmpty(idUser) && !String.IsNullOrEmpty(idDealer))
                {
                    headers.Add("idDealer", idDealer);
                    headers.Add("idUser", idUser);
                }
                request.xmlContent = isB64 ? Encoding.UTF8.GetString(Convert.FromBase64String(xml)) : xml;
                request.extras = ObservacionesAdicionales;
                request.logo = b64Logo;
                request.templateId = templateId.ToString();
                var content = new StringContent(JsonConvert.SerializeObject(
                    request, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }),
                Encoding.UTF8, "application/json");
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(_apiUrl,
                                string.Format("/pdf/v1/api/GeneratePdf",
                                _operation), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio para generar PDF.
        /// </summary>
        /// <param name="xml">XML timbrado.</param>
        /// <param name="b64Logo">Logo en B64.</param>
        /// <param name="templateId">Identificador de la plantilla.</param>
        /// <param name="ObservacionesAdicionales">Observaciones adicionales.</param>
        /// <param name="isB64">Especifica si el XML está en B64.</param>
        /// <returns></returns>
        public virtual async Task<PdfResponse> GenerarPdfAsync(string xml, string b64Logo, PdfTemplates templateId, Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, templateId, null, null, ObservacionesAdicionales, isB64);
        }
        public virtual async Task<PdfResponse> GenerarPdfAsync(string xml, string b64Logo, string idUser, string idDealer, PdfTemplates templateId, Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {   
            return await GeneratePdfAsync(xml, b64Logo, templateId, idUser, idDealer, ObservacionesAdicionales, isB64);
        }
        public virtual async Task<PdfResponse> GenerarPdfDefaultAsync(string xml, string b64Logo,  Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, PdfTemplates.cfdi40, null, null, ObservacionesAdicionales, isB64);
        }
    }
}
