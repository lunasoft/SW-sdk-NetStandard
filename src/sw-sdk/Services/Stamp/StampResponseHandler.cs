using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SW.Helpers;
using SW.Handlers;

namespace SW.Services.Stamp
{

    internal class StampResponseHandlerV1 : ResponseHandler<StampResponseV1>
    {
    }
    internal class StampResponseHandlerV2 : ResponseHandler<StampResponseV2>
    {
        public StampResponseHandlerV2()
        {
        }

        public StampResponseHandlerV2(string xmlOriginal) : base(xmlOriginal)
        {
        }

        public override async Task<StampResponseV2> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            var response = await base.GetPostResponseAsync(url, path, headers, content, proxy);
            if (base.Has307AndAddenda(response, response.data))
                response.data.cfdi = base.GetCfdiData(response, response.data.cfdi, path.ToLower().EndsWith("b64"));
            return response;
        }
    }
    internal class StampResponseHandlerV3 : ResponseHandler<StampResponseV3>
    {
        public StampResponseHandlerV3()
        {
        }

        public StampResponseHandlerV3(string xmlOriginal) : base(xmlOriginal)
        {
        }

        public override async Task<StampResponseV3> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            var response = await base.GetPostResponseAsync(url, path, headers, content, proxy);
            if (base.Has307AndAddenda(response, response.data))
                response.data.cfdi = base.GetCfdiData(response, response.data.cfdi, path.ToLower().EndsWith("b64"));
            return response;
        }
    }
    internal class StampResponseHandlerV4 : ResponseHandler<StampResponseV4>
    {
        public override async Task<StampResponseV4> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            var response = await base.GetPostResponseAsync(url, path, headers, content, proxy);
            if (base.Has307AndAddenda(response, response.data))
                response.data.cfdi = base.GetCfdiData(response, response.data.cfdi, path.ToLower().EndsWith("b64"));
            return response;
        }
        public StampResponseHandlerV4()
        {
        }

        public StampResponseHandlerV4(string xmlOriginal) : base(xmlOriginal)
        {
        }
    }
}
