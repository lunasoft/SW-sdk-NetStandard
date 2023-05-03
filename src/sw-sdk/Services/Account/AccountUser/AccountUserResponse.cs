using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Account.AccountUser
{
    [DataContract]
    public class AccountUserResponse : Response
    {
        [DataMember]
        public AccountUserData Data { get; set; }
    }
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
        public string IdUsuario { get; set; }
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public int Stamps { get; set; }
        [DataMember]
        public bool Unlimited { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string FechaUltimoPassword { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public bool Administrador { get; set; }
        [DataMember]
        public int Profile { get; set; }
        [DataMember]
        public bool Activo { get; set; }
        [DataMember]
        public string RegisteredDate { get; set; }
        [DataMember]
        public bool Eliminado { get; set; }
        [DataMember]
        public string TokenAccess { get; set; }
    }
    [DataContract]
    internal class AccountUserTempResponse : Response
    {
        [DataMember]
        internal string Data { get; set; }
    }
}
