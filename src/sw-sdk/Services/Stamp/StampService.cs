using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class StampService : Services
    {
        protected StampService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {

        }
        protected StampService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal virtual MultipartFormDataContent GetMultipartContent(byte[] xml)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            ByteArrayContent fileContent = new ByteArrayContent(xml);
            content.Add(fileContent, "xml", "xml");
            return content;
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
                Validation.ValidateCustomId(customId);
                headers.Add("customId", customId.Length > 100 ? customId.HashTo256() : customId);
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
