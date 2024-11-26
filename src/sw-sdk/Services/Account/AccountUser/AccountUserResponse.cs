using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Account.AccountUser
{
    /// <summary>
    /// Estructura de la respuesta que se obtiene en los metodos Crear usuarios
    /// </summary>
    [DataContract]
    public class AccountUserResponse : Response
    {
        [DataMember]
        public AccountUserData Data { get; set; }
    }
    /// <summary>
    /// Estructura de la respuesta que se obtiene en los metodos de Consulta
    /// </summary>
    [DataContract]
    public class AccountUsersResponse : Response
    {
        [DataMember]
        public AccountUserData[] Data { get; set; }
    }
    [DataContract]
    public class AccountUserData
    {
        [DataMember]
        public string IdUser { get; set; }
        [DataMember]
        public string IdDealer { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TaxId { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string LastPasswordChange { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
        [DataMember]
        public int Profile { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string RegisteredDate { get; set; }
        [DataMember]
        public string AccessToken { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
    /// <summary>
    /// Estructura de la respuesta que se obtiene en los metodos Modificar y eliminar usuarios
    /// </summary>
    [DataContract]
    public class AccountUserTempResponse : Response
    {
        [DataMember]
        internal string Data { get; set; }
    }
}
