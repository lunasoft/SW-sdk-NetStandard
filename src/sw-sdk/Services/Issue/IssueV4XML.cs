

using SW.Services.Stamp;

namespace SW.Services.Issue
{
    public class IssueV4XML : BaseStampV4XML
    {
        /// <summary>
        /// Crear una instancia de la clase IssueV4.
        /// </summary>
        /// <remarks>Método para realizar el timbrado de CFDI's muy grandes (más de 10000 nodos).</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4XML(string url, string urlApi, string user, string password, int proxyPort = 0, string proxy = null) : base(url, urlApi, user, password, "issue", proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase IssueV4.
        /// </summary>
        /// <remarks>Método para realizar el timbrado de CFDI's muy grandes (más de 10000 nodos)..</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4XML(string url, string urlApi, string token, int proxyPort = 0, string proxy = null) : base(url, urlApi, token, "issue", proxy, proxyPort)
        {
        }
    }
}
