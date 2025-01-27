﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Pdf
{
    public abstract class PdfService : Services
    {
        protected PdfService(string urlApi, string url, string user, string password, string proxy, int proxyPort) : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        protected PdfService(string urlApi, string token, string proxy, int proxyPort) : base(urlApi, token, proxy, proxyPort)
        {
        }
        internal StringContent GetStringContent(string xml, string b64Logo, string templateId, Dictionary<string, string> observacionesAdicionales, bool isB64)
        {
            var request = new PdfRequest();
            request.XmlContent = isB64 ? Encoding.UTF8.GetString(Convert.FromBase64String(xml)) : xml;
            request.Extras = observacionesAdicionales;
            request.Logo = b64Logo;
            request.TemplateId = templateId;
            var content = new StringContent(JsonConvert.SerializeObject(
                request, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }),
            Encoding.UTF8, "application/json");
            return content;
        }
    }
}
