using SW.Services.Stamp;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace SW.Helpers
{
    internal static class XmlUtils
    {
        internal static string AddAddenda(string cfdiOriginal, string cfdiStamped,bool isb64)
        {
            string cfdi = cfdiStamped;
            try
            {
                cfdiOriginal = isb64 ? Encoding.UTF8.GetString(Convert.FromBase64String(cfdiOriginal)) : cfdiOriginal;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(cfdiOriginal);
                XmlNode addenda = null;
                var elements = xmlDocument.GetElementsByTagName("cfdi:Addenda");
                if (elements != null && elements.Count > 0)
                {
                    addenda = elements[0];
                    if (addenda != null)

                        if (addenda != null && addenda.HasChildNodes)
                        {
                            XmlDocument xmlDocumentStamped = new XmlDocument();
                            xmlDocumentStamped.LoadXml(cfdiStamped);
                            var addendaEl = xmlDocumentStamped.CreateElement(addenda.Prefix, addenda.LocalName, addenda.NamespaceURI);
                            addendaEl.InnerXml = addenda.InnerXml;
                            xmlDocumentStamped.DocumentElement.AppendChild(addendaEl);
                            cfdi = xmlDocumentStamped.OuterXml;
                        }
                }
            }
            catch (Exception)
            {
                //TODO: Report Error
            }
            return cfdi;
        }
        public static StampResponseV2 DowloadFileAsync(string url, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    var result = client.GetAsync(url).Result;
                    return TryGetFile(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new StampResponseV2()
                {
                    Message = wex.Message,
                    Status = "error",
                    MessageDetail = wex.StackTrace
                };
            }
        }
        internal static StampResponseV2 TryGetFile(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new StampResponseV2
                    {
                        Data = new DataCfdiTfd
                        {
                            Cfdi = response.Content.ReadAsStringAsync().Result,
                            Tfd = null
                        },
                        Status = "error"
                    };
                }
                else
                {
                    return new StampResponseV2()
                    {
                        Message = ((int)response.StatusCode).ToString(),
                        Status = "error",
                        MessageDetail = response.ReasonPhrase
                    };
                }
            }
            catch (Exception)
            {
                return new StampResponseV2()
                {
                    Message = ((int)response.StatusCode).ToString(),
                    Status = "error",
                    MessageDetail = response.ReasonPhrase
                };
            }
        }
        internal static string GetUUIDFromTFD(string tfd)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(tfd);
                return doc.DocumentElement.Attributes.GetNamedItem("UUID").Value;
            }
            catch (Exception)
            {
                throw new ServicesException("No es posible obtener el UUID");
            }
        }
    }
}
