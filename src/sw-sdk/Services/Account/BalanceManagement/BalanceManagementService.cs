using SW.Entities;
using sw_sdk.Services.Account.BalanceManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Services.Account.BalanceManagement
{
    public abstract class BalanceManagementService : Services
    {
        /// <summary>
        /// Balance Management con sobrecarga que recibe usuario y contraseña
        /// </summary>
        /// <param name="urlApi">URL de la API que se usará</param>
        /// <param name="url">URL Services que realiza la autenticación</param>
        /// <param name="user">Correo del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>
        protected BalanceManagementService(string urlApi, string url, string user, string password, string proxy, int proxyPort) : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Balance Management con sobrecarga que token
        /// </summary>
        /// <param name="url">URL de la API que se usará</param>
        /// <param name="token">Token de la cuenta del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>
        protected BalanceManagementService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Metodo que muestra el balance de timbres de un usuario
        /// </summary>
        /// <param name="idUser">ID del usuario a consultar timbres</param>
        /// <returns>Regresa un objeto Response</returns>
        internal abstract Task<BalanceResponse> GetBalanceID(Guid idUser);

        /// <summary>
        /// Metodo para añadir timbres a una cuenta hijo desde la cuenta dealer
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le asignaran los timbres</param>
        /// <param name="stamps">Cantidad de timbres a agregar</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns>Retorna un objeto handler</returns>
        internal abstract Task<BalanceManagementResponse> AddStamps(Guid idUser, int stamps, string comment);

        /// <summary>
        /// Metodo para eliminar timbres de una cuenta hijo desde la cuenta dealer
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le eliminaran los timbres</param>
        /// <param name="stamps">Cantidad de timbres a agregar</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns>Retorna un objeto handler</returns>
        internal abstract Task<BalanceManagementResponse> RemoveStamps(Guid idUser, int stamps, string comment);

        /// <summary>
        /// Metodo auxiliar para enviar los headers a la requests
        /// </summary>
        /// <returns>Un objeto Dictionary con los headers y sus valores</returns>
        internal virtual async Task<Dictionary<string, string>> GetHeadersAsync()
        {
            await this.SetupRequestAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "Bearer " + this.Token }
                };
            return headers;
        }
    }
}
