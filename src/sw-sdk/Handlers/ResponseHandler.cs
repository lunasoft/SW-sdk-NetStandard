using SW.Entities;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SW.Services.Stamp;

namespace SW.Handlers
{
    internal class ResponseHandler<T>
        where T : Response, new()
    {
        private readonly ResponseHandlerExtended<T> _handler;
        public readonly string _xmlOriginal;
        internal ResponseHandler() 
        {
            _handler = new ResponseHandlerExtended<T>();
        }
        internal ResponseHandler(string xmlOriginal)
        {
            _handler = new ResponseHandlerExtended<T>();
            _xmlOriginal = xmlOriginal;
        }
        internal virtual async Task<T> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    client.BaseAddress = new Uri(url);
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    var result = await client.PostAsync(path, content);
                    return await _handler.TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return _handler.GetExceptionResponse(wex);
            }
        }
        internal virtual async Task<T> GetPostResponseAsync(string url, Dictionary<string, string> headers, string path, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    client.BaseAddress = new Uri(url);
                    var result = await client.PostAsync(path, null);
                    return await _handler.TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return _handler.GetExceptionResponse(wex);
            }
        }

        internal virtual async Task<T> GetResponseAsync(string url, Dictionary<string, string> headers, string path, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    client.BaseAddress = new Uri(url);
                    var result = await client.GetAsync(path);
                    return await _handler.TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return _handler.GetExceptionResponse(wex);
            }
        }
        internal async Task<T> DeleteResponseAsync(string url, Dictionary<string, string> headers, string path, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    client.BaseAddress = new Uri(url);
                    var result = await client.DeleteAsync(path);
                    return await _handler.TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return _handler.GetExceptionResponse(wex);
            }
        }
        
        internal virtual string GetCfdiData(Response response, string cfdi, bool isb64)
        {
            try
            {

                return XmlUtils.AddAddenda(_xmlOriginal, cfdi, isb64);

            }
            catch (Exception)
            {
            }
            return cfdi;
        }
        internal virtual bool Has307AndAddenda(Response response, Data_CFDI data)
        {
            try
            {
                if (response.status == "error" &&
               (response.message != null && response.message.Trim().ToLower().Replace(".", "").Contains("307 el comprobante contiene un timbre previo"))
               && (data != null && !string.IsNullOrEmpty(data.cfdi)))
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        internal virtual bool Has307AndAddenda(Response response, Data_CFDI_TFD data)
        {
            try
            {
                if (response.status == "error" &&
               (response.message != null && response.message.Trim().ToLower().Replace(".", "").Contains("307 el comprobante contiene un timbre previo"))
               && (data != null && !string.IsNullOrEmpty(data.cfdi)))
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        internal T HandleException(Exception ex)
        {
            return _handler.GetExceptionResponse(ex);
        }
    }
}
