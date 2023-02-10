using SW.Services.Pdf;
namespace SW.Services.Pdf
{
    public class Pdf : BasePdf
    {
        /// <summary>
        /// Crear una instancia de la clase Pdf.
        /// </summary>
        /// <remarks>Incluye métodos de generación de PDF.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Email del usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pdf(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, urlApi, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Pdf.
        /// </summary>
        /// <remarks>Incluye métodos de generación de PDF.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pdf(string urlApi, string token, int proxyPort = 0, string proxy = null) : base(urlApi, token, proxy, proxyPort)
        {
        }
    }
}
