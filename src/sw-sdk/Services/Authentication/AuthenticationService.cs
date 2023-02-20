using System.Threading.Tasks;

namespace SW.Services.Authentication
{
    public abstract class AuthenticationService : Services
    {

        protected AuthenticationService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        public abstract Task<AuthResponse> GetTokenAsync();
    }
}
