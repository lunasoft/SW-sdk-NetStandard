namespace SW.Services.Pdf
{
    public class Pdf : BasePdf
    {
        public Pdf(string urlAuth, string urlApi, string user, string password, int proxyPort = 0, string proxy = null) : base(urlAuth, urlApi, user, password, "pdf", proxy, proxyPort)
        {
        }
        public Pdf(string urlApi, string token, int proxyPort = 0, string proxy = null) : base(urlApi, urlApi, token, "pdf", proxy, proxyPort)
        {
        }
    }
}
