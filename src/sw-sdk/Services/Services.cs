using System;
using System.Threading.Tasks;
using SW.Helpers;

namespace SW.Services
{
    public abstract class Services
    {
        private string _token;
        private readonly string _url;
        private readonly string _urlApi;
        private readonly string _user;
        private readonly string _password;
        private readonly string _proxy;
        private readonly int _proxyPort;
        private DateTime _expirationDate;
        private readonly int _timeSession = 2;
        internal string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        internal string Url
        {
            get { return _url; }
        }
        internal string UrlApi
        {
            get { return _urlApi; }
        }
        internal string User
        {
            get { return _user; }
        }
        internal string Password
        {
            get { return _password; }
        }
        internal string Proxy
        {
            get { return _proxy; }
        }
        internal int ProxyPort
        {
            get { return _proxyPort; }
        }
        internal DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }
        protected Services()
        {

        }
        protected Services(string url, string token, string proxy, int proxyPort)
        {
            _url = Helpers.RequestHelper.NormalizeBaseUrl(url); ;
            _token = token;
            _expirationDate = DateTime.Now.AddYears(_timeSession);
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
        protected Services(string url, string user, string password, string proxy, int proxyPort)
        {
            _url = Helpers.RequestHelper.NormalizeBaseUrl(url); ;
            _user = user;
            _password = password;
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
        protected Services(string urlApi, string url, string user, string password, string proxy, int proxyPort)
        {
            _urlApi = RequestHelper.NormalizeBaseUrl(urlApi);
            _url = Helpers.RequestHelper.NormalizeBaseUrl(url);
            _user = user;
            _password = password;
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
        internal async Task<Services> SetupRequestAsync()
        {
            if (string.IsNullOrEmpty(Token) || DateTime.Now > ExpirationDate)
            {
                Authentication.Authentication auth = new Authentication.Authentication(Url,User,Password, ProxyPort, Proxy);
                var response = await auth.GetTokenAsync();
                if (response.Status == ResponseType.Success.ToString().ToLower())
                {
                    Token = response.Data.Token;
                    ExpirationDate = DateTime.Now.AddHours(_timeSession);
                }
            }
            return this;
        }
    }
}
