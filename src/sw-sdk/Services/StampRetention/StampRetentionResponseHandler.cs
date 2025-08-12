using SW.Handlers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SW.Services.StampRetention
{
    internal class StampRetentionResponseHandlerV3 : ResponseHandler<StampRetentionResponseV3>
    {
        internal StampRetentionResponseHandlerV3() 
        {
        }
        internal StampRetentionResponseHandlerV3(string xmlOriginal) : base(xmlOriginal)
        {
        }
        internal override async Task<StampRetentionResponseV3> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            var response = await base.GetPostResponseAsync(url, path, headers, content, proxy);
            return response;
        }
    }
}
