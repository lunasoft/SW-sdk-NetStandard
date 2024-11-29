using System;
using SW.Helpers;
using System.Threading.Tasks;
using SW.Handlers;
using sw_sdk.Services.Account.AccountBalance;
using SW.Entities;

namespace SW.Services.Account.AccountBalance
{
    public class AccountBalance : AccountBalanceService
    {
        /// <summary>
        /// Crear una instancia de la clase AccountBalance.
        /// </summary>
        /// <remarks>Incluye métodos para consultar saldo, agregar y eliminar timbres.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public AccountBalance(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase AccountBalance.
        /// </summary>
        /// <remarks>Incluye métodos para consultar saldo, agregar y eliminar timbres.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public AccountBalance(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Metodo que obtiene el balance de timbres del usuario.
        /// </summary>
        /// <returns><see cref="BalanceResponse"/></returns>
        public async Task<BalanceResponse> ConsultarSaldoAsync()
        {
            return await GetBalance();
        }
        /// <summary>
        /// Metodo para añadir timbres a una cuenta hijo desde la cuenta dealer.
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le asignaran los timbres.</param>
        /// <param name="stamps">Cantidad de timbres a agregar.</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns><see cref="AccountBalanceResponse"/></returns>
        public async Task<AccountBalanceResponse> AgregarTimbresAsync(Guid idUser, int stamps, string comment)
        {
            return await StampsDistribution(idUser, stamps, ActionsAccountBalance.Add, comment);
        }
        /// <summary>
        /// Metodo para eliminar timbres a una cuenta hijo desde la cuenta dealer.
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le eliminaran los timbres.</param>
        /// <param name="stamps">Cantidad de timbres a eliminar.</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns><see cref="AccountBalanceResponse"/></returns>
        public async Task<AccountBalanceResponse> EliminarTimbresAsync(Guid idUser, int stamps, string comment)
        {
            return await StampsDistribution(idUser, stamps, ActionsAccountBalance.Remove, comment);
        }

        internal async override Task<BalanceResponse> GetBalance()
        {
            ResponseHandler<BalanceResponse> handler = new ResponseHandler<BalanceResponse>();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await Helpers.RequestHelper.GetHeadersAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetResponseAsync(this.UrlApi ?? this.Url, headers,"management/v2/api/users/balance", proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
    }
}