using SW.Handlers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SW.Services.Storage
{
    internal class StorageResponseHandler : ResponseHandler<StorageResponse>
    {
        internal async Task<StorageResponse> GetStorageResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            var result = await GetResponseAsync(url, headers, path, proxy);
            return result.data?.records.Count <= 0 ? HandleException(new Exception("No se encuentra registro del timbrado.")) : result;
        }
    }
    internal class StorageExtraResponseHandler : ResponseHandler<StorageExtraResponse>
    {
        internal async Task<StorageExtraResponse> GetStorageExtrasResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            var result = await GetResponseAsync(url, headers, path, proxy);
            return result.data?.records.Count <= 0 ? HandleException(new Exception("No se encuentra registro del timbrado.")) : result;
        }
    }
}
