using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Services.StampRetention
{
    public class StampRetention : BaseStampRetention
    {
        /// <summary>
        /// Crea una instancia de la clase StampRetention.
        /// </summary>
        /// <remarks>Incluye métodos para el Timbrado de CFDI's de retenciones sellados en formato XML con respuesta V3</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public StampRetention(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "stamp", proxy, proxyPort)
        { 
        }

        /// <summary>
        /// Crea una instancia de la clase StampRetention .
        /// </summary>
        /// <remarks>Incluye métodos para el Timbrado de CFDI's de retenciones sellados en formato XML con respuesta V3</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public StampRetention(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "stamp", proxy, proxyPort)
        {
        }
    }
}
