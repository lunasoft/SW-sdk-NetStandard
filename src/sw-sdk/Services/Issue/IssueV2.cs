using SW.Services.Stamp;

namespace SW.Services.Issue
{
    public class Issue : BaseStamp
    {
        /// <summary>
        /// Crear una instancia de la clase Issue.
        /// </summary>
        /// <remarks>Incluye métodos de Emisión Timbrado con respuestas V1, V2, V3, y V4.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Issue(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "issue", proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Issue.
        /// </summary>
        /// <remarks>Incluye métodos de Emisión Timbrado con respuestas V1, V2, V3, y V4.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Issue(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "issue", proxy, proxyPort)
        {
        }
    }
}
