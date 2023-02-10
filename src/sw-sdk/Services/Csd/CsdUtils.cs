using System;
using System.Threading.Tasks;
using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Csd
{
    public class CsdUtils : CsdService
    {
        /// <summary>
        /// Crear una instancia de la clase CsdUtils.
        /// </summary>
        /// <remarks>Incluye métodos para realizar cancelaciones de CFDI.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public CsdUtils(string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(url, user, password, proxy, proxyPort)
        {
            
        }
        /// <summary>
        /// Crear una instancia de la clase CsdUtils.
        /// </summary>
        /// <remarks>Incluye métodos para realizar cancelaciones de CFDI.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticacion.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public CsdUtils(string url, string token, int proxyPort = 0, string proxy = null) 
            : base(url, token, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Servicio para cargar un certificado.
        /// </summary>
        /// <param name="b64Cer">Certificado CSD en formato B64.</param>
        /// <param name="b64Key">Certificado Key en formato B64.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <returns><see cref="CsdResponse"/></returns>
        public async Task<CsdResponse> UploadCsdAsync(string b64Cer, string b64Key, string password)
        {
            return await UploadCsdServiceAsync(b64Cer, b64Key, password);
        }
        /// <summary>
        /// Servicio para eliminar un certificado.
        /// </summary>
        /// <param name="noCertificado">Numero de certificado.</param>
        /// <returns><see cref="CsdResponse"/></returns>
        public async Task<CsdResponse> DeleteCsdAsync(string noCertificado)
        {
            return await DeleteCsdServiceAsync(noCertificado);
        }
        /// <summary>
        /// Servicio para obtener todos los certificados cargados.
        /// </summary>
        /// <returns><see cref="AllCsdResponse"/></returns>
        public async Task<AllCsdResponse> GetAllCsdAsync()
        {
            return await GetAllCsdServiceAsync();
        }
        /// <summary>
        /// Servicio para obtener todos los certificados cargados filtrados por RFC.
        /// </summary>
        /// <param name="rfc">RFC del certificado.</param>
        /// <returns><see cref="AllCsdResponse"/></returns>
        public async Task<AllCsdResponse> GetAllCsdAsync(string rfc)
        {
            return await GetAllCsdServiceAsync(rfc);
        }
        /// <summary>
        /// Servicio para obtener un certificado por numero de certificado.
        /// </summary>
        /// <param name="noCertificado">Número de certificado.</param>
        /// <returns><see cref="GetCsdResponse"/></returns>
        public async Task<GetCsdResponse> GetCsdAsync(string noCertificado)
        {
            return await GetCsdServiceAsync(noCertificado);
        }
    }
}
