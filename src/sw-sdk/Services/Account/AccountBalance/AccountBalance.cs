using System;
using SW.Helpers;
using System.Threading.Tasks;
using SW.Handlers;
using sw_sdk.Services.Account.AccountBalance;

namespace SW.Services.Account.AccountBalance
{
    public class AccountBalance : AccountBalanceService
    {
        private readonly string path = "/management/api/balance";
        /// <summary>
        /// Balance que se genera por usuario y contraseña
        /// </summary>
        /// <param name="urlApi">URL de la API que se usará</param>
        /// <param name="url">URL Services que realiza la autenticación</param>
        /// <param name="user">Correo del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>
        public AccountBalance(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) : base(urlApi, url, user, password, proxy, proxyPort)
        {
        }
        /// <summary>
        /// Balance que requiere del token para mostrar los datos
        /// </summary>
        /// <param name="url">URL de la API que se usará</param>
        /// <param name="token">Token de la cuenta del usuario</param>
        /// <param name="proxyPort">Port</param>
        /// <param name="proxy">Proxy</param>

        public AccountBalance(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
        }
        internal async override Task<BalanceResponse> GetBalanceID(Guid idUser)
        {
            ResponseHandler<BalanceResponse> handler = new ResponseHandler<BalanceResponse>();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetResponseAsync(this.UrlApi ?? this.Url, headers, String.Format("{0}/{1}", path, idUser), proxy);
            }
            catch (Exception e)
            {
                return handler.HandleException(e);
            }
        }
        /// <summary>
        /// Metodo que obtiene el balance de timbres del usuario
        /// </summary>
        /// <param name="idUser">ID del usuario a consultar timbres</param>
        /// <returns>Retorna un objeto handler</returns>
        public async Task<BalanceResponse> ConsultarSaldoAsync(Guid idUser)
        {
            return await GetBalanceID(idUser);
        }
        internal async override Task<AccountBalanceResponse> StampsDistribution(Guid idUser, int stamps,ActionsAccountBalance action, string comment)
        {
            ResponseHandler<AccountBalanceResponse> handler = new ResponseHandler<AccountBalanceResponse>();
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                var headers = await GetHeadersAsync();
                var content = GetStringContent(comment);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.GetPostResponseAsync(this.UrlApi ?? this.Url, String.Format("{0}/{1}/"+action.ToString().ToLower()+"/{2}", path, idUser, stamps), headers, content, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        /// <summary>
        /// Metodo para añadir timbres a una cuenta hijo desde la cuenta dealer
        /// </summary>
        /// <param name="idUser">ID del usuario al que se le asignaran los timbres</param>
        /// <param name="stamps">Cantidad de timbres a agregar</param>
        /// <param name="comment">Comentario agregado al movimiento.</param>
        /// <returns>Retorna un objeto handler</returns>
        public async Task<AccountBalanceResponse> DistribucionTimbresAsync(Guid idUser, int stamps, ActionsAccountBalance action, string comment)
        {
            return await StampsDistribution(idUser, stamps, action, comment);
        }
    }
}