using SW.Helpers;
using System.Runtime.Serialization;

namespace SW.Services.Account.AccountUser
{
    [DataContract]
    public partial class AccountUserRequest
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TaxId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int Stamps { get; set; }
        [DataMember]
        public bool IsUnlimited { get; set; } = false;
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string NotificationEmail { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
