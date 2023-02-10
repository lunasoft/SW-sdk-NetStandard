﻿using SW.Services.Stamp;

namespace SW.Services.Issue
{
    public class IssueV4 : BaseStampV4
    {
        /// <summary>
        /// Crear una instancia de la clase IssueV4.
        /// </summary>
        /// <remarks>Incluye métodos de Emisión Timbrado V4 con respuestas V1, V2, V3, y V4.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "issue", proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase IssueV4.
        /// </summary>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "issue", proxy, proxyPort)
        {
        }
    }
}
