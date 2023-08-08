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
        public readonly string XmlOriginal;
        internal ResponseHandler()
        {
            _handler = new ResponseHandlerExtended<T>();
        }
        internal ResponseHandler(string xmlOriginal)
        {
            _handler = new ResponseHandlerExtended<T>();
            XmlOriginal = xmlOriginal;
        }
        internal virtual async Task<T> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    client.BaseAddress = new Uri(url);
                    client.Timeout = TimeSpan.FromMinutes(5);
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
                return _handler.GetExceptionResponse<T>(wex);
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
                return _handler.GetExceptionResponse<T>(wex);
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
                return _handler.GetExceptionResponse<T>(wex);
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
                return _handler.GetExceptionResponse<T>(wex);
            }
        }
        internal async Task<T> PutResponseAsync(string url, Dictionary<string, string> headers, string path, HttpContent content, HttpClientHandler proxy)
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
                    var result = await client.PutAsync(path, content);
                    return await _handler.TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return _handler.GetExceptionResponse<T>(wex);
            }
        }

        internal virtual string GetCfdiData(Response response, string cfdi, bool isb64)
        {
            try
            {

                return XmlUtils.AddAddenda(XmlOriginal, cfdi, isb64);

            }
            catch (Exception)
            {
            }
            return cfdi;
        }
        internal virtual bool Has307AndAddenda(Response response, DataCfdi data)
        {
            try
            {
                if (response.Status == "error" &&
               (response.Message != null && response.Message.Trim().ToLower().Replace(".", "").Contains("307 el comprobante contiene un timbre previo"))
               && (data != null && !string.IsNullOrEmpty(data.Cfdi)))
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        internal virtual bool Has307AndAddenda(Response response, DataCfdiTfd data)
        {
            try
            {
                if (response.Status == "error" &&
               (response.Message != null && response.Message.Trim().ToLower().Replace(".", "").Contains("307 el comprobante contiene un timbre previo"))
               && (data != null && !string.IsNullOrEmpty(data.Cfdi)))
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
            return _handler.GetExceptionResponse<T>(ex);
        }
    }
}
