using SW.Services.Pdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Services.Pdf
{
    public class PdfGeneric : BasePdf
    {
        public PdfGeneric(string urlAuth, string urlApi, string user, string password, int proxyPort = 0, string proxy = null) : base(urlAuth, urlApi, user, password, "pdf", proxy, proxyPort)
        {
        }
        public PdfGeneric(string urlApi, string token, int proxyPort = 0, string proxy = null) : base(urlApi, urlApi, token, "pdf", proxy, proxyPort)
        {
        }
    }
}
