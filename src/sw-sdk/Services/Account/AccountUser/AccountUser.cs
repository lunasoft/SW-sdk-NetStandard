using System;
using SW.Helpers;
using SW.Entities;
using System.Threading.Tasks;

namespace SW.Services.Account.AccountUser
{
    public class AccountUser : AccountUserService
    {
        /// <summary>
        /// Crear una instancia de la clase AccountUser.
        /// </summary>
        /// <remarks>Incluye métodos para consultar saldo, agregar y eliminar timbres.</remarks>
        /// <param name="urlApi">Url Api.</param>
        /// <param name="url">Url Services.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public AccountUser(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(urlApi, url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase AccountUser.
        /// </summary>
        /// <remarks>Incluye métodos para consultar saldo, agregar y eliminar timbres.</remarks>
        /// <param name="url">Url Services.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public AccountUser(string urlApi, string token, int proxyPort = 0, string proxy = null) 
            : base(urlApi, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio para crear un usuario.
        /// </summary>
        /// <param name="request">Contiene la información relacionada con el usuario a crear.</param>
        /// <returns><see cref="Response"/></returns>
        public async Task<Response> CrearUsuarioAsync(AccountUserRequest request)
        {
            return await UserServiceAsync(AccountUserAction.Add, request: request);
        }
        /// <summary>
        /// Servicio para modificar la informacion de un usuario existente.
        /// </summary>
        /// <param name="idUsuario">UUID del usuario.</param>
        /// <param name="rfc">Actualiza el RFC del usuario.</param>
        /// <param name="nombre">Actualiza el nombre del usuario.</param>
        /// <param name="timbradoIlimitado">Especifica si el timbrado del usuario es ilimitado.</param>
        /// <returns><see cref="Response"/></returns>
        public async Task<Response> ModificarUsuarioAsync(Guid idUsuario, string rfc = null, string nombre = null, bool timbradoIlimitado = false)
        {
            return await UserServiceAsync(AccountUserAction.Update, idUsuario, new AccountUserRequest 
            { Name = nombre, Rfc = rfc, Unlimited = timbradoIlimitado });
        }
        /// <summary>
        /// Servicio para eliminar un usuario.
        /// </summary>
        /// <param name="idUsuario">UUID del usuario.</param>
        /// <returns><see cref="Response"/></returns>
        public async Task<Response> EliminarUsuarioAsync(Guid idUsuario)
        {
            return await UserServiceAsync(AccountUserAction.Delete, idUsuario);
        }
        /// <summary>
        /// Servicio que obtiene la informacion del usuario a partir del token obtenido en la creacion de la instancia AccountUser.
        /// </summary>
        /// <returns><see cref="AccountUserResponse"/></returns>
        public async Task<AccountUserResponse> ObtenerUsuarioAsync()
        {
            return await GetUserServiceAsync();
        }
        /// <summary>
        /// Servicio que obtiene la informacion de un usuario a partir de su UUID.
        /// </summary>
        /// <param name="idUsuario">UUID del usuario.</param>
        /// <returns><see cref="AccountUserResponse"/></returns>
        public async Task<AccountUserResponse> ObtenerUsuarioAsync(Guid idUsuario) 
        {
            return await GetUserServiceAsync(idUsuario);
        }
        /// <summary>
        /// Servicio que obtiene el listado de todos los usuarios registrados con la cuenta especificada en la creacion de la instancia AccountUser.
        /// </summary>
        /// <returns><see cref="AccountUsersResponse"/></returns>
        public async Task<AccountUsersResponse> ObtenerUsuariosAsync()
        {
            return await GetUsersServiceAsync();
        }
    }
}
