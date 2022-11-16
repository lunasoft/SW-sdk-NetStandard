using SW.Helpers;
using SW.Services.Storage;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class BaseStampV4XML : StampService
    {
        private string _operation;
        private string _apiUrl;
        
        public BaseStampV4XML(string url,string urlApi, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
            _apiUrl = urlApi;
        }

        public BaseStampV4XML(string url, string urlApi, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
            _apiUrl = urlApi;
        }
        
        public virtual async Task<StampResponseV2> TimbrarV2XMLAsync(string xml, string email = null, string customId = null, bool isb64 = false, string[] extras = null)
        {
            StampResponseHandlerV2XML handler = new StampResponseHandlerV2XML(xml);

            string format = isb64 ? "b64" : "";
            var xmlBytes = Encoding.UTF8.GetBytes(xml);
            var headers = await GetHeadersAsync(email, customId, extras);
            var content = GetMultipartContent(xmlBytes);
            var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);

            var response = await handler.GetPostResponseAsync(this.Url,
                            string.Format("v4/cfdi33/{0}/{1}/{2}",
                            _operation,
                            StampTypes.v2.ToString(),
                            format), headers, content, proxy);

            if(response.status == "error" && response.message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.")
            {
                StorageResponseHandler storangeHandler = new StorageResponseHandler();
                string uuid = Helpers.XmlUtils.GetUUIDFromTFD(response.data.tfd);
                var xmlFromStorange = await storangeHandler.GetResponseAsync(_apiUrl,
                                        headers, $"datawarehouse/v1/live/{uuid}",
                                        Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort));

                if(string.IsNullOrEmpty(xmlFromStorange.data.records[0].urlAckCfdi))
                    throw new ServicesException("No es posible obtener el url para decargar el XML");

                var dataResult = await Helpers.DowloadFile.DowloadFileAsync(xmlFromStorange.data.records[0].urlXml,
                                    Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort));
                dataResult.data.tfd = response.data.tfd;
                dataResult.message = response.message;

                return dataResult;
            }
            return response;
        }
    }
}

