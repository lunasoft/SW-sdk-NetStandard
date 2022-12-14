using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SW.Entities;
using SW.Handlers;
using SW.Helpers;
using sw_sdk.Helpers;

namespace SW.Services.Pdf
{
    public abstract partial class BasePdf : PdfService
    {
        private string _apiUrl;
        private readonly ResponseHandler<PdfResponse> _handler;
        protected BasePdf(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _apiUrl = url;
            _handler = new ResponseHandler<PdfResponse>();
        }
        protected BasePdf(string url, string urlApi, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _apiUrl = urlApi;
            _handler = new ResponseHandler<PdfResponse>();
        }
        internal virtual async Task<PdfResponse> GeneratePdfAsync(string xml, string b64Logo, string templateId, Dictionary<string, string> ObservacionesAdicionales, bool isB64)
        {
            try
            {
                var headers = await GetHeadersAsync();
                var content = GetStringContent(xml, b64Logo, templateId, ObservacionesAdicionales, isB64);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(_apiUrl,"/pdf/v1/api/GeneratePdf", headers, content, proxy);
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal virtual async Task<PdfResponse> RegeneratePdfAsync(Guid uuid)
        {
            try
            {
                var headers = await GetHeadersAsync();
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var result = await _handler.GetPostResponseAsync(_apiUrl, headers, String.Format("/pdf/v1/api/RegeneratePdf/{0}", uuid), proxy);
                result.status = result.status ?? "success";
                return result;
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio para generar PDF con plantillas genericas.
        /// </summary>
        /// <param name="xml">XML timbrado.</param>
        /// <param name="b64Logo">Logo en B64.</param>
        /// <param name="templateId">Identificador de la plantilla.</param>
        /// <param name="ObservacionesAdicionales">Observaciones adicionales.</param>
        /// <param name="isB64">Especifica si el XML está en B64.</param>
        /// <returns></returns>
        public virtual async Task<PdfResponse> GenerarPdfAsync(string xml, string b64Logo, PdfTemplates templateId, Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, templateId.ToString(), ObservacionesAdicionales, isB64);
        }
        /// <summary>
        /// Servicio para generar PDF con plantillas personalizadas.
        /// </summary>
        /// <param name="xml">XML timbrado.</param>
        /// <param name="b64Logo">Logo en B64.</param>
        /// <param name="templateId">Identificador de la plantilla.</param>
        /// <param name="ObservacionesAdicionales">Observaciones adicionales.</param>
        /// <param name="isB64">Especifica si el XML está en B64.</param>
        /// <returns></returns>
        public virtual async Task<PdfResponse> GenerarPdfAsync(string xml, string b64Logo, string templateId, Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, templateId, ObservacionesAdicionales, isB64);
        }
        /// <summary>
        /// Servicio para generar PDF con plantilla por defecto CFDI 4.0.
        /// </summary>
        /// <param name="xml">XML timbrado.</param>
        /// <param name="b64Logo">Logo en B64.</param>
        /// <param name="ObservacionesAdicionales">Observaciones adicionales.</param>
        /// <param name="isB64">Especifica si el XML está en B64.</param>
        /// <returns></returns>
        public virtual async Task<PdfResponse> GenerarPdfDefaultAsync(string xml, string b64Logo, Dictionary<string, string> ObservacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, PdfTemplates.cfdi40.ToString(), ObservacionesAdicionales, isB64);
        }
        /// <summary>
        /// Servicio para regenerar PDF de un comprobante previamente timbrado.
        /// </summary>
        /// <param name="uuid">Folio fiscal del comprobante.</param>
        /// <returns>PdfResponse</returns>
        public async Task<PdfResponse> RegenerarPdfAsync(Guid uuid)
        {
            return await RegeneratePdfAsync(uuid);
        } 
    }
}
