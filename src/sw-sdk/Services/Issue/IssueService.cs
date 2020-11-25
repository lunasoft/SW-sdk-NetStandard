using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SW.Services.Issue
{
    public abstract class IssueService : Services
    {
        protected IssueService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected IssueService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }

        internal virtual async Task<HttpWebRequest> RequestStampJsonAsync(string json, string version, string operation)
        {
            await this.SetupRequestAsync();
            var request = (HttpWebRequest)WebRequest.Create(this.Url + string.Format("v3/cfdi33/{0}/{1}", operation, version));
            request.ContentType = "application/jsontoxml";
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add(HttpRequestHeader.Authorization.ToString(), "bearer " + this.Token);
            Helpers.RequestHelper.SetupProxy(this.Proxy, this.ProxyPort, ref request);
            request.ContentLength = json.Length;
            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return request;
        }

        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            return headers;
        }

        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync(string email, string customId, string[] extras)
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            if (email != null && ValidateEmail(email))
            {
                headers.Add("email", email);
            }
            if (customId != null)
            {
                headers.Add("customId", customId);
            }
            if (extras != null)
            {
                headers.Add("extra", string.Join(",", extras));
            }
            return headers;
        }

        internal virtual bool ValidateEmail(string email)
        {
            try 
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch 
            {
                return false;
            }
        }
    }
}
