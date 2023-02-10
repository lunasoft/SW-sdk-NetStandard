using System;
using SW.Helpers;
using SW.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using SW.Handlers;

namespace SW.Services.Storage
{
    public class Storage : StorageService
    {
        /// <summary>
        /// Crear una instancia de la clase Storage.
        /// </summary>
        /// <remarks>Incluye métodos para la obtención del registro de un timbrado.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Storage(string urlApi, string token, int proxyPort = 0, string proxy = null) 
            : base(urlApi, token, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Storage.
        /// </summary>
        /// <remarks>Incluye métodos para la obtención del registro de un timbrado.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Storage(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null)
            : base (urlApi, url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de recuperación de XML por UUID. Obtiene las URL de descarga de la información almacenada en storage, 
        /// tal como el XML timbrado, Acuse de CFDI, Acuse de cancelación, PDF y Addenda.
        /// </summary>
        /// <param name="uuid">UUID del comprobante timbrado.</param>
        /// <returns><see cref="StorageResponse"/></returns>
        public async Task<StorageResponse> GetXmlAsync(Guid uuid)
        {
            return await GetByUuidAsync(uuid);
        }
        /// <summary>
        /// Servicio de recuperación de XML por UUID. Adicional a las URL de descarga, se obtienen todos los datos extras correspondientes al 
        /// comprobante timbrado.
        /// </summary>
        /// <param name="uuid">UUID del comprobante timbrado.</param>
        /// <returns><see cref="StorageResponse"/></returns>
        public async Task<StorageExtraResponse> GetXmlExtrasAsync(Guid uuid)
        {
            return await GetByUuidExtrasAsync(uuid);
        }
    }
}
