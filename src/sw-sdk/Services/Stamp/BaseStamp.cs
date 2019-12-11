using SW.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SW.Services.Stamp
{
    public abstract class BaseStamp : StampService
    {
        private string _operation;
        public BaseStamp(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        public BaseStamp(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        public virtual async Task<StampResponseV1> TimbrarV1Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
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
                                StampTypes.v1.ToString(),
                                format), headers, content, proxy);

            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual ConcurrentDictionary<string, StampResponseV1> TimbrarV1(string[] xmls, bool isb64 = false)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
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
                                    StampTypes.v1.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        public virtual async Task<StampResponseV2> TimbrarV2Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2();
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
                                StampTypes.v2.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual ConcurrentDictionary<string, StampResponseV2> TimbrarV2(string[] xmls, bool isb64 = false)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2();
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
                                    StampTypes.v2.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        public virtual async Task<StampResponseV3> TimbrarV3Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3();
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
                                StampTypes.v3.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual ConcurrentDictionary<string, StampResponseV3> TimbrarV3(string[] xmls, bool isb64 = false)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3();
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
                                    StampTypes.v3.ToString(),
                                    format), headers, content, proxy));
                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        public virtual async Task<StampResponseV4> TimbrarV4Async(string xml, bool isb64 = false)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
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
                                StampTypes.v4.ToString(),
                                format), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual ConcurrentDictionary<string, StampResponseV4> TimbrarV4(string[] xmls, bool isb64 = false)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
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
                                    StampTypes.v4.ToString(),
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
