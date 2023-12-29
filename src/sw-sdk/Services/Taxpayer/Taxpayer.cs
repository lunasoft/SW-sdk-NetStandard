using SW.Handlers;
using SW.Helpers;
using SW.Services.Pendings;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Taxpayer
{
    public class Taxpayer : TaxpayerService
    {
        /// <summary>
        /// Crear una instancia de la clase Taxpayer.
        /// </summary>
        /// <remarks>Incluye un método para realizar la consulta de un RFC en la Lista 69 B.</remarks>
        /// <param name="url">URL Services que realiza la autenticación</param>
        /// <param name="user">Correo del usuario.</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Taxpayer(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Taxpayer.
        /// </summary>
        /// <remarks>Incluye un método para realizar la consulta de un RFC en la Lista 69 B.</remarks>
        /// <param name="url">URL Services</param>
        /// <param name="token">Token de la cuenta del usuario</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Taxpayer(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort) 
        {
        }
        /// <summary>
        /// Servicio para realizar la consulta de un RFC dentro de la Lista 69 B.
        /// </summary>
        /// <param name="rfc">RFC del contribuyente a consultar.</param>
        /// <returns>Respuesta del contribuyente encapsulada en <see cref="TaxpayerResponse"/>.</returns>
        public async Task<TaxpayerResponse> GetTaxpayer (string rfc)
        {
            return await TaxpayerServiceAsync(rfc);
        }
    }
}
