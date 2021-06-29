﻿using SW.Entities;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SW.Services
{
    internal abstract class ResponseHandler<T>
        where T : Response, new()
    {
        public ResponseHandler() { }
        public readonly string _xmlOriginal;
        public ResponseHandler(string xmlOriginal)
        {
            _xmlOriginal = xmlOriginal;
        }
        public virtual async Task<T> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
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
                    return await TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new T()
                {
                    message = wex.Message,
                    status = "error",
                    messageDetail = wex.StackTrace
                };
            }
        }
        public virtual async Task<T> GetPostResponseAsync(string url, Dictionary<string, string> headers, string path, HttpClientHandler proxy)
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
                    return await TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new T()
                {
                    message = wex.Message,
                    status = "error",
                    messageDetail = wex.StackTrace
                };
            }
        }

        public virtual async Task<T> GetResponseAsync(string url, Dictionary<string, string> headers, string path, HttpClientHandler proxy)
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
                    return await TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new T()
                {
                    message = wex.Message,
                    status = "error",
                    messageDetail = wex.StackTrace
                };
            }
        }
        public abstract T HandleException(Exception ex);
        internal virtual async Task<T> TryGetResponseAsync(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                else
                    return new T()
                    {
                        message = ((int)response.StatusCode).ToString(),
                        status = "error",
                        messageDetail = response.ReasonPhrase
                    };
            }
            catch (Exception)
            {
                return new T()
                {
                    message = ((int)response.StatusCode).ToString(),
                    status = "error",
                    messageDetail = response.ReasonPhrase
                };
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
        internal virtual bool Has307AndAddenda(Response response, Stamp.Data_CFDI data)
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
        internal virtual bool Has307AndAddenda(Response response, Stamp.Data_CFDI_TFD data)
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
    }
}
