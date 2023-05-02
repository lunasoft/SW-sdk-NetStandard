using SW.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using SW.Handlers;

namespace SW.Services.Stamp
{
    public abstract class BaseStamp : StampService
    {
        private string _operation;
        protected BaseStamp(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        protected BaseStamp(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV1"/></returns>
        public virtual async Task<StampResponseV1> TimbrarV1Async(string xml, bool isb64 = false)
        {
            ResponseHandler<StampResponseV1> handler = new ResponseHandler<StampResponseV1>();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/{0}/{1}/{2}",
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
        /// Servicio de timbrado masivo de multiples CFDI's previamente sellados en formato XML.
        /// </summary>
        /// <param name="xmls">String array de los CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si los XML están en base 64.</param>
        /// <returns><see cref="ConcurrentDictionary{Tkey, TValue}"/>
        /// <br/>TKey is <see cref="string"/>
        /// <br/>TValue is <see cref="StampResponseV1"/>
        /// </returns>
        public virtual ConcurrentDictionary<string, StampResponseV1> TimbrarV1Async(string[] xmls, bool isb64 = false)
        {
            ResponseHandler<StampResponseV1> handler = new ResponseHandler<StampResponseV1>();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV1> response = new ConcurrentDictionary<string, StampResponseV1>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, async i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = await GetHeadersAsync();
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, await handler.GetPostResponseAsync(this.Url,
                                    string.Format("cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.V1.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV2"/></returns>
        public virtual async Task<StampResponseV2> TimbrarV2Async(string xml, bool isb64 = false)
        {
            ResponseHandler<StampResponseV2> handler = new ResponseHandler<StampResponseV2>();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/{0}/{1}/{2}",
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
        /// Servicio de timbrado masivo de multiples CFDI's previamente sellados en formato XML.
        /// </summary>
        /// <param name="xmls">String array de los CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si los XML están en base 64.</param>
        /// <returns><see cref="ConcurrentDictionary{Tkey, TValue}"/>
        /// <br/>TKey is <see cref="string"/>
        /// <br/>TValue is <see cref="StampResponseV2"/>
        /// </returns>
        public virtual ConcurrentDictionary<string, StampResponseV2> TimbrarV2Async(string[] xmls, bool isb64 = false)
        {
            ResponseHandler<StampResponseV2> handler = new ResponseHandler<StampResponseV2>();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV2> response = new ConcurrentDictionary<string, StampResponseV2>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, async i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = await GetHeadersAsync();
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, await handler.GetPostResponseAsync(this.Url,
                                    string.Format("cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.V2.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV3"/></returns>
        public virtual async Task<StampResponseV3> TimbrarV3Async(string xml, bool isb64 = false)
        {
            ResponseHandler<StampResponseV3> handler = new ResponseHandler<StampResponseV3>();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/{0}/{1}/{2}",
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
        /// Servicio de timbrado masivo de multiples CFDI's previamente sellados en formato XML.
        /// </summary>
        /// <param name="xmls">String array de los CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si los XML están en base 64.</param>
        /// <returns><see cref="ConcurrentDictionary{Tkey, TValue}"/>
        /// <br/>TKey is <see cref="string"/>
        /// <br/>TValue is <see cref="StampResponseV3"/>
        /// </returns>
        public virtual ConcurrentDictionary<string, StampResponseV3> TimbrarV3Async(string[] xmls, bool isb64 = false)
        {
            ResponseHandler<StampResponseV3> handler = new ResponseHandler<StampResponseV3>();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV3> response = new ConcurrentDictionary<string, StampResponseV3>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, async i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = await GetHeadersAsync();
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, await handler.GetPostResponseAsync(this.Url,
                                    string.Format("cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.V3.ToString(),
                                    format), headers, content, proxy));
                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si el XML está en base 64.</param>
        /// <returns><see cref="StampResponseV4"/></returns>
        public virtual async Task<StampResponseV4> TimbrarV4Async(string xml, bool isb64 = false)
        {
            ResponseHandler<StampResponseV4> handler = new ResponseHandler<StampResponseV4>();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/{0}/{1}/{2}",
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
        /// Servicio de timbrado masivo de multiples CFDI's previamente sellados en formato XML.
        /// </summary>
        /// <param name="xmls">String array de los CFDI en formato XML.</param>
        /// <param name="isb64">Especifica si los XML están en base 64.</param>
        /// <returns><see cref="ConcurrentDictionary{Tkey, TValue}"/>
        /// <br/>TKey is <see cref="string"/>
        /// <br/>TValue is <see cref="StampResponseV4"/>
        /// </returns>
        public virtual ConcurrentDictionary<string, StampResponseV4> TimbrarV4Async(string[] xmls, bool isb64 = false)
        {
            ResponseHandler<StampResponseV4> handler = new ResponseHandler<StampResponseV4>();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV4> response = new ConcurrentDictionary<string, StampResponseV4>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, async i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = await GetHeadersAsync();
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, await handler.GetPostResponseAsync(this.Url,
                                    string.Format("cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.V4.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
    }
}
