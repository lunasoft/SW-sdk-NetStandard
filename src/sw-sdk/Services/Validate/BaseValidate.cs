using SW.Handlers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Validate
{
    public abstract class BaseValidate : ValidateService
    {
        private readonly string _operation;
        private readonly ResponseHandler<ValidateXmlResponse> _handler;
        protected BaseValidate(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
            _handler = new ResponseHandler<ValidateXmlResponse>();
        }
        protected BaseValidate(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
            _handler = new ResponseHandler<ValidateXmlResponse>();
        }
        /// <summary>
        /// Servicio para validar un CFDI en formato XML.
        /// </summary>
        /// <param name="xml">XML del CFDI en formato string.</param>
        /// <returns><see cref="ValidateXmlResponse"/></returns>
        public virtual async Task<ValidateXmlResponse> ValidateXmlAsync(string xml)
        {
            try
            {
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                string.Format("validate/cfdi33/",
                                _operation), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
    }
}
