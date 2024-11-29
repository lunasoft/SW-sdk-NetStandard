using Newtonsoft.Json;
using SW.Entities;
using SW.Handlers;
using SW.Helpers;
using sw_sdk.Services.Account.AccountUser;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Account.AccountUser
{
    public abstract class AccountUserService : Services
    {
        private readonly string _path = "management/v2/api/dealers/users";
        protected AccountUserService(string urlApi, string url, string user, string password, int proxyPort, string proxy)
        : base(urlApi,url, user, password, proxy, proxyPort)
        {
        }
        protected AccountUserService(string urlApi, string token, int proxyPort, string proxy) 
        : base (urlApi, token, proxy, proxyPort) 
        {
        }

        internal async Task<AccountUserResponse> UserCreation(AccountUserRequest request)
        {
            var handler = new AccountCreateUserResponseHandler();
            var headers = await RequestHelper.GetHeadersAsync(this);
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            return await handler.SendRequestAsync(this.UrlApi ?? this.Url, headers, _path,
                request is null ? null : GetStringContent(request), proxy);
        }

        internal async Task<AccountUserTempResponse> UserServiceAsync(AccountUserAction action, Guid idUser, AccountUserUpdateRequest request = null)
        {
            var handler = new AccountUserResponseHandler();
            var headers = await RequestHelper.GetHeadersAsync(this);
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            var path = String.Format("{0}/{1}", _path, idUser);
            return await handler.SendRequestAsync(action, this.UrlApi ?? this.Url, headers, path, 
                    request is null ? null : GetStringContent(request), proxy);
        }
        internal async Task<AccountUsersResponse> GetUsers(AccountUserFilter filter, string parameter=null, Guid? idUser=null, bool? isActive=null)
        {
            var handler = new ResponseHandler<AccountUsersResponse>();
            var headers = await RequestHelper.GetHeadersAsync(this);
            var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
            string path = GetEndpoint(filter, parameter, idUser, isActive);
            return await handler.GetResponseAsync(this.UrlApi ?? this.Url, headers, path, proxy);
        }
        private StringContent GetStringContent<T>(T request)
        {
            return new StringContent(JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }), Encoding.UTF8, "application/json");
        }
        private string GetEndpoint(AccountUserFilter Filter, string parameter = null, Guid? idUser = null, bool? isActive = null)
        {
            string endpoint = null;
            switch (Filter)
            {
                case AccountUserFilter.All:
                    endpoint = _path;
                    break;
                case AccountUserFilter.Email:
                    endpoint = $"{_path}?Email={parameter}";
                    break;
                case AccountUserFilter.TaxId:
                    endpoint = $"{_path}?TaxId={parameter}";
                    break;
                case AccountUserFilter.Id:
                    endpoint = $"{_path}?IdUser={idUser}";
                    break;
                case AccountUserFilter.IsActive:
                    endpoint = $"{_path}?IsActive={isActive}";
                    break;
            }
            return endpoint;
        }
    }
}
