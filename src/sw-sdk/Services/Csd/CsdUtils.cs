using System;
using System.Threading.Tasks;
using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Csd
{
    public class CsdUtils : CsdService
    {
        private readonly ResponseHandler<UploadCsdResponse> _handler;
        public CsdUtils(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<UploadCsdResponse>();
        }
        public CsdUtils(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new ResponseHandler<UploadCsdResponse>();
        }

        internal override async Task<UploadCsdResponse> UploadCsdAsync(string cer, string key, string password, string certificateType, bool isActive)
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                if (String.IsNullOrEmpty(cer) || String.IsNullOrEmpty(key))
                {
                    throw new ServicesException("El certificado o llave privada vienen vacios");
                }
                var headers = await GetHeadersAsync();
                var content = await this.RequestCsdAsync(cer, key, password, certificateType, isActive);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                "certificates/save", headers, content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        public async Task<UploadCsdResponse> UploadMyCsdAsync(string cer, string key, string password, string certificateType, bool isActive)
        {
            return await UploadCsdAsync(cer, key, password, certificateType, isActive);
        }
    }
}
