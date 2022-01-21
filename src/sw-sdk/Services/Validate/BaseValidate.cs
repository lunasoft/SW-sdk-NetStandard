using System;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Validate
{
    public abstract class BaseValidate : ValidateService
    {
        private string _operation;
        public BaseValidate(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        public BaseValidate(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        public virtual async Task<ValidateXmlResponse> ValidateXmlAsync(string XML)
        {
            ValidateXmlResponseHandler handler = new ValidateXmlResponseHandler();
            try
            {
                var xmlBytes = Encoding.UTF8.GetBytes(XML);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("validate/cfdi33/",
                                _operation), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
