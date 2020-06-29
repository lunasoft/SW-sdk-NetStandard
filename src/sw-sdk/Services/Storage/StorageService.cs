using SW.Entities;
using SW.Helpers;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SW.Services.Storage
{
    public abstract class StorageService : Services
    {
        protected StorageService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected StorageService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal abstract Task<Response> GetByUUID(Guid uuid);
    }
}
