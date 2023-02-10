namespace SW.Services.Stamp
{
    public class StampV4 : BaseStampV4
    {
        /// <summary>
        /// Crear una instancia de la clase StampV4.
        /// </summary>
        /// <remarks>Incluye métodos para el Timbrado V4 de CFDI's sellados en formato XML con respuestas V1, V2, V3, y V4.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public StampV4(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "stamp", proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase StampV4.
        /// </summary>
        /// <remarks>Incluye métodos para el Timbrado V4 de CFDI's sellados en formato XML con respuestas V1, V2, V3, y V4.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public StampV4(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "stamp", proxy, proxyPort)
        {
        }
    }
}
