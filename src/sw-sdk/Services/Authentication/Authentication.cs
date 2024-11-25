using SW.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Services.Authentication
{
    public class Authentication : AuthenticationService
    {
        private readonly ResponseHandler<AuthResponse> _handler;
        /// <summary>
        /// Crear una instancia de la clase Authentication.
        /// </summary>
        /// <remarks>Incluye método la obtención del token.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Authentication(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new ResponseHandler<AuthResponse>();
        }
        public override async Task<AuthResponse> GetTokenAsync()
        {
            try
            {
                new AuthenticationValidation(Url, User, Password, Token);
                var content = GetStringContent(this.User, this.Password);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url, "v2/security/authenticate", content, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }
    }
}
