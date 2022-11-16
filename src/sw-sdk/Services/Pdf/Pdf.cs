namespace SW.Services.Pdf
{
    public class Pdf : BasePdf
    {
        /// <summary>
        /// Crear una instancia de la clase PDF.
        /// </summary>
        /// <param name="urlApi">URL API.</param>
        /// <param name="url">URL Services.</param>
        /// <param name="user">Email del usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pdf(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, urlApi, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase PDF.
        /// </summary>
        /// <param name="urlApi">URL API.</param>
        /// <param name="token">Token de autenticacion.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pdf(string urlApi, string token, int proxyPort = 0, string proxy = null) : base(urlApi, token, proxy, proxyPort)
        {
        }
    }
}
