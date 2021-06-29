using System.Collections.Generic;
using System.Threading.Tasks;

namespace sw_sdk.Services.Resend
{
    public abstract class ResendService : SW.Services.Services
    {
        protected ResendService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected ResendService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "Bearer " + this.Token }
                };
            return headers;
        }
    }
}
