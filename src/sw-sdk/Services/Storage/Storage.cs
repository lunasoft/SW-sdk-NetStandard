using System;
using SW.Helpers;
using SW.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SW.Services.Storage
{
    public class Storage : StorageService
    {

        StorageResponseHandler _handler;
        /// <summary>
        /// This Service is Not Implemented
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        public Storage(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new StorageResponseHandler();
        }

        internal async override Task<Response> GetByUUID(Guid uuid)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url, headers, $"datawarehouse/v1/live/{uuid.ToString()}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        public async Task<StorageResponse> GetByUUIDAsync(Guid uuid)
        {
            return (StorageResponse)await GetByUUID(uuid);
        }
    }
}
