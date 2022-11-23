using System;
using System.Threading.Tasks;

namespace SW.Services.Resend
{
    public class Resend : ResendService
    {
        /// <summary>
        /// Crear una instancia de la clase Resend.
        /// </summary>
        /// <param name="urlApi"></param>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="proxyPort"></param>
        /// <param name="proxy"></param>
        public Resend(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null)
            : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Resend.
        /// </summary>
        /// <param name="urlApi"></param>
        /// <param name="token"></param>
        /// <param name="proxyPort"></param>
        /// <param name="proxy"></param>
        public Resend(string urlApi, string token, int proxyPort = 0, string proxy = null)
            : base(urlApi, token, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Servicio para realizar el reenvío del XML y/o PDF a los correos especificados. El PDF se envia si fue generado en el proceso de timbrado.
        /// </summary>
        /// <param name="uuid">Folio del comprobante timbrado.</param>
        /// <param name="email">Correo que se hará el reenvío. (Max. 5).</param>
        /// <returns>ResendResponse</returns>
        public async Task<ResendResponse> ResendEmailAsync(Guid uuid, string email)
        {
            return await ResendEmailServiceAsync(uuid, new[] { email });
        }
        /// <summary>
        /// Servicio para realizar el reenvío del XML y/o PDF a los correos especificados. El PDF se envia si fue generado en el proceso de timbrado.
        /// </summary>
        /// <param name="uuid">Folio del comprobante timbrado.</param>
        /// <param name="email">Listado de correos a los que se hará el reenvío. (Max. 5).</param>
        /// <returns>ResendResponse</returns>
        public async Task<ResendResponse> ResendEmailAsync(Guid uuid, string[] email)
        {
            return await ResendEmailServiceAsync(uuid, email);
        }
    }
}
