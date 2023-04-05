using SW.Helpers;
using System.Runtime.Serialization;

namespace SW.Services.Account.AccountUser
{
    [DataContract]
    public partial class AccountUserRequest
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Rfc { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public int Stamps { get; set; }
        [DataMember]
        public bool Unlimited { get; set; } = false;
        [DataMember]
        public AccountUserProfile ProfileType { get; set; } 
    }
    public partial class AccountUserRequest
    {
        [DataMember]
        internal int Profile { get; set; }
    }
}
