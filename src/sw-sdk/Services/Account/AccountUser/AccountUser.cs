using System;
using SW.Helpers;
using SW.Entities;
using System.Threading.Tasks;
using sw_sdk.Services.Account.AccountUser;

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
        /// <param name="urlApi">Url Api.</param>
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
        /// <returns><see cref="AccountUserResponse"/></returns>
        public async Task<AccountUserResponse> CrearUsuarioAsync(AccountUserRequest request)
        {
            return await UserCreation(request: request);
        }
        /// <summary>
        /// Servicio para modificar la informacion de un usuario existente.
        /// </summary>
        /// <param name="idUser">UUID del usuario.</param>
        /// <param name="taxId">Actualiza el RFC del usuario.</param>
        /// <param name="name">Actualiza el nombre del usuario.</param>
        /// <param name="notificationEmail">Actualiza el correo para recibir notificaciones del usuario.</param>
        /// <param name="phone">Actualiza el númeto de telefono del usuario.</param>
        /// <param name="isUnLimited">Especifica si el timbrado del usuario es ilimitado.</param>
        /// <returns><see cref="Response"/></returns>
        public async Task<AccountUserTempResponse> ModificarUsuarioAsync(Guid idUser, string name = null, string taxId=null, string notificationEmail=null, string phone=null, bool isUnLimited = false)
        {
            return await UserServiceAsync(AccountUserAction.Update, idUser, new AccountUserUpdateRequest 
            { IdUser = idUser, Name = name, TaxId = taxId, NotificationEmail= notificationEmail, Phone= phone, IsUnlimited = isUnLimited });
        }
        /// <summary>
        /// Servicio para eliminar un usuario.
        /// </summary>
        /// <param name="idUser">UUID del usuario.</param>
        /// <returns><see cref="Response"/></returns>
        public async Task<AccountUserTempResponse> EliminarUsuarioAsync(Guid idUser)
        {
            return await UserServiceAsync(AccountUserAction.Delete, idUser);
        }

        /// <summary>
        /// Servicio que obtiene el listado de todos los usuarios registrados con la cuenta especificada en la creacion de la instancia AccountUser.
        /// </summary>
        /// <returns><see cref="AccountUserResponse"/></returns>
        public async Task<AccountUsersResponse> ObtenerUsuariosAsync()
        {
            return await GetUsers(AccountUserFilter.All);
        }
        /// <summary>
        /// Servicio que obtiene la informacion de un usuario a partir de su UUID.
        /// </summary>
        /// <param name="idUser">UUID del usuario.</param>
        /// <returns><see cref="AccountUserResponse"/></returns>
        public async Task<AccountUsersResponse> ObtenerUsuariosByIdAsync(Guid idUser) 
        {
            return await GetUsers(AccountUserFilter.Id, null, idUser);
        }
        /// <summary>
        /// Servicio que obtiene la informacion de un usuario a partir de su Email
        /// </summary>
        /// <returns><see cref="AccountUsersResponse"/></returns>
        public async Task<AccountUsersResponse> ObtenerUsuariosByEmailAsync(string email)
        {
            return await GetUsers(AccountUserFilter.Email, email);
        }
        /// <summary>
        /// Servicio que obtiene la informacion de un usuario a partir de su RFC
        /// </summary>
        /// <returns><see cref="AccountUsersResponse"/></returns>
        public async Task<AccountUsersResponse> ObtenerUsuariosByTaxIdAsync(string taxId)
        {
            return await GetUsers(AccountUserFilter.TaxId, taxId);
        }
        /// <summary>
        /// Servicio que obtiene la informacion de los usuarios que estan activos o no
        /// </summary>
        /// <returns><see cref="AccountUsersResponse"/></returns>
        public async Task<AccountUsersResponse> ObtenerUsuariosByIsActiveAsync(bool isActive)
        {
            return await GetUsers(AccountUserFilter.IsActive, null, null, isActive);
        }
    }
}
