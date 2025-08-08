using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SW.Services.StampRetention
{
    public abstract class StampRetentionService : Services
    {
        protected StampRetentionService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        { 
        }
        protected StampRetentionService(string url, string token, string proxy, int proxyPort) : base (url, token, proxy, proxyPort) 
        { 
        }

        internal virtual MultipartFormDataContent GetMultipartContent (byte[] xml)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            ByteArrayContent fileContent = new ByteArrayContent(xml);
            content.Add(fileContent, "xml", "xml");
            return content;
        }
    }
}
