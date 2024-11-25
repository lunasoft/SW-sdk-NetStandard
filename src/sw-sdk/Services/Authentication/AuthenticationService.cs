using Newtonsoft.Json;
using SW.Services.Account.AccountBalance;
using sw_sdk.Services.Authentication;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Authentication
{
    public abstract class AuthenticationService : Services
    {
        protected AuthenticationService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        public abstract Task<AuthResponse> GetTokenAsync();
        /// <summary>
        /// Metodo que serializa el usuario y contraseña a json y agrega los headers Content-Type, Content-Length
        /// </summary>
        /// <param name="user">Comentario del movimiento en string </param>
        /// <param name="password">Comentario del movimiento en string </param>
        /// <returns></returns>
        internal virtual StringContent GetStringContent(string user, string password)
        {
            var request = new AuthenticationRequest();
            request.User = user;
            request.Password = password;
            var content = new StringContent(JsonConvert.SerializeObject(
                request, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }),
            Encoding.UTF8, "application/json");
            return content;
        }
    }
}
