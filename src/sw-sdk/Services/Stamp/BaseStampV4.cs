﻿using SW.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class BaseStampV4 : StampService
    {
        private string _operation;
        protected BaseStampV4(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        protected BaseStampV4(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV1"/></returns>
        public virtual async Task<StampResponseV1> TimbrarV1Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V1.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV2"/></returns>
        public virtual async Task<StampResponseV2> TimbrarV2Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V2.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV3"/></returns>
        public virtual async Task<StampResponseV3> TimbrarV3Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V3.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML. Si se especifica recibe un Custom Id y 
        /// puede realizar el envío del CFDI y PDF por correo.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="email">Correo para el envío del CFDI y PDF.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <param name="extras">Agrega datos extras en la generación del PDF.</param>
        /// <returns><see cref="StampResponseV4"/></returns>
        public virtual async Task<StampResponseV4> TimbrarV4Async(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4(xml);
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this, email, customId, extras);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.V4.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI en formato XML que tengan entre 10000 y 120000 nodos cfdi:Concepto.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <returns><see cref="StampResponseV1"/></returns>
        public virtual async Task<StampResponseV1> TimbrarV1TooLongAsync(string xml)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this);
                var content = GetMultipartContent(xmlBytes, true);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi/{0}/{1}/zip",
                                _operation,
                                StampTypes.V1.ToString(),
                                false), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
