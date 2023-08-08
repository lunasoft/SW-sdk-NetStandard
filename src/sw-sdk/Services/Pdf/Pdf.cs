using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SW.Handlers;
using SW.Helpers;
using sw_sdk.Helpers;

namespace SW.Services.Pdf
{
    public class Pdf : PdfService
    {
        private readonly ResponseHandler<PdfResponse> _handler;
        public Pdf(string urlApi, string url, string user, string password, string proxy = null, int proxyPort = 0) : base(urlApi, url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<PdfResponse>();
        }
        public Pdf(string urlApi, string token, string proxy = null, int proxyPort = 0) : base(urlApi, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<PdfResponse>();
        }
        internal virtual async Task<PdfResponse> GeneratePdfAsync(string xml, string b64Logo, string templateId, Dictionary<string, string> observacionesAdicionales, bool isB64)
        {
            try
            {
                await this.SetupRequestAsync();
                var headers = Helpers.RequestHelper.GetHeaders(this.Token);
                var content = GetStringContent(xml, b64Logo, templateId, observacionesAdicionales, isB64);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.UrlApi ?? this.Url, "/pdf/v1/api/GeneratePdf", headers, content, proxy);
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
                await this.SetupRequestAsync();
                var headers = Helpers.RequestHelper.GetHeaders(this.Token);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var result = await _handler.GetPostResponseAsync(UrlApi ?? Url, headers, String.Format("/pdf/v1/api/RegeneratePdf/{0}", uuid), proxy);
                result.Status = result.Status ?? "success";
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
        /// <param name="observacionesAdicionales">Observaciones adicionales.</param>
        /// <param name="isB64">Especifica si el XML está en B64.</param>
        /// <returns></returns>
        public async Task<PdfResponse> GenerarPdfAsync(string xml, string b64Logo, PdfTemplates templateId, Dictionary<string, string> observacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, templateId.ToString(), observacionesAdicionales, isB64);
        }
        /// <summary>
        /// Servicio para generar PDF con plantillas personalizadas.
        /// </summary>
        /// <param name="xml">XML timbrado.</param>
        /// <param name="b64Logo">Logo en B64.</param>
        /// <param name="templateId">Identificador de la plantilla.</param>
        /// <param name="observacionesAdicionales">Observaciones adicionales.</param>
        /// <param name="isB64">Especifica si el XML está en B64.</param>
        /// <returns></returns>
        public async Task<PdfResponse> GenerarPdfAsync(string xml, string b64Logo, string templateId, Dictionary<string, string> observacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, templateId, observacionesAdicionales, isB64);
        }
        /// <summary>
        /// Servicio para generar PDF con plantilla por defecto CFDI 4.0.
        /// </summary>
        /// <param name="xml">XML timbrado.</param>
        /// <param name="b64Logo">Logo en B64.</param>
        /// <param name="observacionesAdicionales">Observaciones adicionales.</param>
        /// <param name="isB64">Especifica si el XML está en B64.</param>
        /// <returns></returns>
        public async Task<PdfResponse> GenerarPdfDefaultAsync(string xml, string b64Logo, Dictionary<string, string> observacionesAdicionales = null, bool isB64 = false)
        {
            return await GeneratePdfAsync(xml, b64Logo, PdfTemplates.cfdi40.ToString(), observacionesAdicionales, isB64);
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
