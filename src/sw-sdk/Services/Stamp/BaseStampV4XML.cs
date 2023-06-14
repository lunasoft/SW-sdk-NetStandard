using SW.Handlers;
using SW.Helpers;
using SW.Services.Storage;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class BaseStampV4XML : StampService
    {
        private string _operation;
        private string _apiUrl;
        protected BaseStampV4XML(string url, string urlApi, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _apiUrl = urlApi;
            _operation = operation;
        }
        protected BaseStampV4XML(string url, string urlApi, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _apiUrl = urlApi; 
            _operation = operation;
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <returns><see cref="StampResponseV1"/></returns>
        public virtual async Task<StampResponseV1> TimbrarV1TooLongAsync(string xml)
        {
            ResponseHandler<StampResponseV1> handler = new ResponseHandler<StampResponseV1>();
            try
            {
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContentZip(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/{0}/{1}/zip",
                                _operation,
                                StampTypes.V1.ToString(),
                                false), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Servicio de timbrado de un CFDI previamente sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <returns><see cref="StampResponseV4"/></returns>
        public virtual async Task<StampResponseV4> TimbrarV4TooLongAsync(string xml)
        {
            ResponseHandler<StampResponseV2> handler = new ResponseHandler<StampResponseV2>(xml);
            try
            {
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = await GetHeadersAsync();
                var content = GetMultipartContentZip(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var response = await handler.GetPostResponseAsync(this.Url,
                                string.Format("cfdi33/{0}/{1}/zip",
                                _operation,
                                StampTypes.V1.ToString(),
                                false), headers, content, proxy);
                if (response.Status != "error" && response.Message != "307. El comprobante contiene un timbre previo.")
                {
                    StorageResponseHandler storangeHandler = new StorageResponseHandler();
                    string uuid = XmlUtils.GetUUIDFromTFD(response.Data.Tfd);
                    var xmlFromStorange = storangeHandler.GetResponseAsync(this._apiUrl, headers,
                                            $"datawarehouse/v1/live/{uuid}",
                                            RequestHelper.ProxySettings(this.Proxy, this.ProxyPort));
                    var xmlStorange = xmlFromStorange.Result.Data.Records.ElementAtOrDefault(0)?.UrlXml;
                    if (string.IsNullOrEmpty(xmlStorange))
                    {
                        return new StampResponseV4()
                        {
                            Data = null,
                            Message = "No es posible obtener el url para descargar el XML",
                            Status = "error",
                            MessageDetail = "No esta disponible el URL de descarga del XML, intente más tarde"
                        };
                    }
                    var dataResult = XmlUtils.DowloadFileAsync(xmlStorange, RequestHelper.ProxySettings(this.Proxy, this.ProxyPort));
                    dataResult.Data.Tfd = response.Data.Tfd;
                    dataResult.Message = response.Message;
                    return ConvertionHelper.ConvertV2ToV4Response(dataResult);
                }
                return ConvertionHelper.ConvertV2ToV4Response(response);
            }
            catch (Exception ex)
            {
                return ConvertionHelper.ConvertV2ToV4Response(handler.HandleException(ex));
            }
        }

    }
}
