using SW.Handlers;
using SW.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.Relations
{
    public class Relations : RelationsService
    {
        private readonly ResponseHandler<RelationsResponse> _handler;
        public Relations(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<RelationsResponse>();
        }
        public Relations(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<RelationsResponse>();
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(string cer, string key, string rfc, string password, string uuid)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = this.RequestRelations(cer, key, rfc, password, uuid);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "relations/csd", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(byte[] xmlCancelation)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = this.RequestRelations(xmlCancelation);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "relations/xml", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(string pfx, string rfc, string password, string uuid)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = this.RequestRelations(pfx, rfc, password, uuid);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "relations/pfx", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
        internal override async Task<RelationsResponse> RelationsRequestAsync(string rfc, string uuid)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                HttpWebRequest request = await this.RequestRelationsAsync(rfc, uuid);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Method = WebRequestMethods.Http.Post;
                var headers = await GetHeadersAsync();
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url, headers, $"relations/{rfc}/{uuid}", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }


        public async Task<RelationsResponse> RelationsByCSDAsync(string cer, string key, string rfc, string password, string uuid)
        {
            return await RelationsRequestAsync(cer, key, rfc, password, uuid);
        }
        public async Task<RelationsResponse> RelationsByXMLAsync(byte[] xmlCancelation)
        {
            return await RelationsRequestAsync(xmlCancelation);
        }
        public async Task<RelationsResponse> RelationsByPFXAsync(string pfx, string rfc, string password, string uuid)
        {
            return await RelationsRequestAsync(pfx, rfc, password, uuid);
        }
        public async Task<RelationsResponse> RelationsByRfcUuidAsync(string rfc, string uuid)
        {
            return await RelationsRequestAsync(rfc, uuid);
        }
    }
}
