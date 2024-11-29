using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace sw_sdk.Services.Account.AccountUser
{
    [DataContract]
    public partial class AccountUserUpdateRequest
    {
        [DataMember]
        public Guid IdUser { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TaxId { get; set; }
        [DataMember]
        public string NotificationEmail { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public bool IsUnlimited { get; set; } = false;
    }
}
