using System;
using System.Threading.Tasks;

namespace SW.Services.Resend
{
    public class Resend : ResendService
    {
        /// <summary>
        /// Crear una instancia de la clase Resend.
        /// </summary>
        /// <remarks>Incluye métodos para realizar el reenvío de correos con el XML y PDF.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Resend(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null)
            : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Resend.
        /// </summary>
        /// <remarks>Incluye métodos para realizar el reenvío de correos con el XML y PDF.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Resend(string urlApi, string token, int proxyPort = 0, string proxy = null)
            : base(urlApi, token, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Servicio para realizar el reenvío del XML y/o PDF a los correos especificados. El PDF se envia si fue generado en el proceso de timbrado.
        /// </summary>
        /// <param name="uuid">Folio del comprobante timbrado.</param>
        /// <param name="email">Correo que se hará el reenvío. (Max. 5).</param>
        /// <returns><see cref="ResendResponse"/></returns>
        public async Task<ResendResponse> ResendEmailAsync(Guid uuid, string email)
        {
            return await ResendEmailServiceAsync(uuid, new[] { email });
        }
        /// <summary>
        /// Servicio para realizar el reenvío del XML y/o PDF a los correos especificados. El PDF se envia si fue generado en el proceso de timbrado.
        /// </summary>
        /// <param name="uuid">Folio del comprobante timbrado.</param>
        /// <param name="email">Listado de correos a los que se hará el reenvío. (Max. 5).</param>
        /// <returns><see cref="ResendResponse"/></returns>
        public async Task<ResendResponse> ResendEmailAsync(Guid uuid, string[] email)
        {
            return await ResendEmailServiceAsync(uuid, email);
        }
    }
}
