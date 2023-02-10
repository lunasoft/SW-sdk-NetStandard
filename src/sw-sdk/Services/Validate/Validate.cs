namespace SW.Services.Validate
{
    public class Validate : BaseValidate
    {
        /// <summary>
        /// Crear una instancia de la clase Validate.
        /// </summary>
        /// <remarks>Incluye método para la validación de CFDI.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Validate(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "validate", proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Validate.
        /// </summary>
        /// <remarks>Incluye método para la validación de CFDI.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Validate(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "validate", proxy, proxyPort)
        {
        }
    }
}
