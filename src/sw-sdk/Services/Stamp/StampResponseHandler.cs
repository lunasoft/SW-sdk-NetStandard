using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SW.Handlers;

namespace SW.Services.Stamp
{

    internal class StampResponseHandlerV1 : ResponseHandler<StampResponseV1>
    {
    }
    internal class StampResponseHandlerV2 : ResponseHandler<StampResponseV2>
    {
        internal StampResponseHandlerV2()
        {
        }

        internal StampResponseHandlerV2(string xmlOriginal) : base(xmlOriginal)
        {
        }

        internal override async Task<StampResponseV2> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            var response = await base.GetPostResponseAsync(url, path, headers, content, proxy);
            if (base.Has307AndAddenda(response, response.data))
                response.data.cfdi = base.GetCfdiData(response, response.data.cfdi, path.ToLower().EndsWith("b64"));
            return response;
        }
    }
    internal class StampResponseHandlerV3 : ResponseHandler<StampResponseV3>
    {
        internal StampResponseHandlerV3()
        {
        }

        internal StampResponseHandlerV3(string xmlOriginal) : base(xmlOriginal)
        {
        }

        internal override async Task<StampResponseV3> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            var response = await base.GetPostResponseAsync(url, path, headers, content, proxy);
            if (base.Has307AndAddenda(response, response.data))
                response.data.cfdi = base.GetCfdiData(response, response.data.cfdi, path.ToLower().EndsWith("b64"));
            return response;
        }
    }
    internal class StampResponseHandlerV4 : ResponseHandler<StampResponseV4>
    {
        internal override async Task<StampResponseV4> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            var response = await base.GetPostResponseAsync(url, path, headers, content, proxy);
            if (base.Has307AndAddenda(response, response.data))
                response.data.cfdi = base.GetCfdiData(response, response.data.cfdi, path.ToLower().EndsWith("b64"));
            return response;
        }
        internal StampResponseHandlerV4()
        {
        }

        internal StampResponseHandlerV4(string xmlOriginal) : base(xmlOriginal)
        {
        }
    }
}
