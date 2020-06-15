using System;
using System.Collections.Generic;
using System.Text;

namespace sw_sdk.Services.Resend
{
    public class Resend : BaseResend
    {
        public Resend(string urlAuth, string urlApi, string user, string password, int proxyPort = 0, string proxy = null) : base(urlAuth, urlApi, user, password, "pdf", proxy, proxyPort)
        {
        }
        public Resend(string urlApi, string token, int proxyPort = 0, string proxy = null) : base(urlApi, urlApi, token, "pdf", proxy, proxyPort)
        {
        }
    }
}
