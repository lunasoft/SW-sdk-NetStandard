using Newtonsoft.Json;
using SW.Entities;
using SW.Handlers;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Account.AccountUser
{
    public abstract class AccountUserService : Services
    {
        private readonly string _path = "/management/api/users";
        protected AccountUserService(string urlApi, string url, string user, string password, int proxyPort, string proxy)
        : base(urlApi,url, user, password, proxy, proxyPort)
        {
        }
        protected AccountUserService(string urlApi, string token, int proxyPort, string proxy) 
        : base (urlApi, token, proxy, proxyPort) 
        {
        }
        internal async Task<Response> UserServiceAsync(AccountUserAction action, Guid? idUser = null, AccountUserRequest request = null)
        {
            var handler = new AccountUserResponseHandler();
            await this.SetupRequestAsync();
            var headers = Helpers.RequestHelper.GetHeaders(this.Token);
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            return await handler.SendRequestAsync(action, this.UrlApi ?? this.Url, headers, String.Format("{0}/{1}", _path, idUser), 
                    request is null ? null : GetStringContent(request), proxy);
        }
        internal async Task<AccountUserResponse> GetUserServiceAsync(Guid? idUser = null)
        {
            var handler = new ResponseHandler<AccountUserResponse>();
            await this.SetupRequestAsync();
            var headers = Helpers.RequestHelper.GetHeaders(this.Token);
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            return await handler.GetResponseAsync(this.UrlApi ?? this.Url, headers, idUser is null ? String.Format("{0}/{1}", _path, "info") : String.Format("{0}/{1}", _path, idUser), proxy);
        }
        internal async Task<AccountUsersResponse> GetUsersServiceAsync()
        {
            var handler = new ResponseHandler<AccountUsersResponse>();
            await this.SetupRequestAsync();
            var headers = Helpers.RequestHelper.GetHeaders(this.Token);
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            return await handler.GetResponseAsync(this.UrlApi ?? this.Url, headers, _path, proxy);
        }
        private StringContent GetStringContent(AccountUserRequest request)
        {
            request.Profile = (int)request.ProfileType;
            return new StringContent(JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }), Encoding.UTF8, "application/json");
        }
    }
}
