using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Services.Storage
{
    public abstract class StorageService : Services
    {
        protected StorageService(string urlApi, string url, string user, string password, int proxyPort, string proxy) : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        protected StorageService(string urlApi, string token, string proxy, int proxyPort) : base(urlApi, token, proxy, proxyPort)
        {
        }
        internal async Task<StorageResponse> GetByUuidAsync(Guid uuid)
        {
            StorageResponseHandler handler = new StorageResponseHandler();
            try
            {
                await this.SetupRequestAsync();
                var headers = Helpers.RequestHelper.GetHeaders(this.Token);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetStorageResponseAsync(this.UrlApi ?? this.Url, String.Format("datawarehouse/v1/live/{0}", uuid), headers, proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        internal async Task<StorageExtraResponse> GetByUuidExtrasAsync(Guid uuid)
        {
            StorageExtraResponseHandler handler = new StorageExtraResponseHandler();
            try
            {
                await this.SetupRequestAsync();
                Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetStorageExtrasResponseAsync(this.UrlApi ?? this.Url, String.Format("datawarehouse/v1/live/{0}", uuid), headers, proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
    }
}
