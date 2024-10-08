﻿using ExternalServices;
using ExternalServices.ConsultaCFDIService;
using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace SW.Services.Status
{
    public abstract class StatusService : SATServices
    {
        private static BasicHttpBinding _myBinding;
        protected StatusService(string url, int receiveTimeoutInSeconds) : base(url)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
              delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };
            _myBinding = GetBinding(receiveTimeoutInSeconds);
        }
        internal abstract Acuse StatusRequest(string rfcEmisor, string rfcReceptor, string total, string uuid, string sello);
        internal virtual Acuse RequestStatus(string rfcEmisor, string rfcReceptor, string total, string uuid, string sello)
        {
            var fe = !String.IsNullOrEmpty(sello) && sello.Length >= 8 ? sello.Substring(sello.Length - 8) : String.Empty;
            var consulta = "?re=" + rfcEmisor.ToUpper() + "&rr=" + rfcReceptor.ToUpper() + "&tt=" + total + "&id=" + uuid.ToUpper() + "&fe=" + fe;
            Acuse acuse = null;

            for (int i = 0; i < 3; i++)
            {
                acuse = ConsultaCFDIService(consulta);
                if (acuse != null)
                    break;
            }
            return acuse;
        }
        private Acuse ConsultaCFDIService(string consulta)
        {
            try
            {
                using (var client = new ConsultaCFDIServiceClient(_myBinding, new EndpointAddress(this.Url)))
                {
                    return client.Consulta(consulta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
