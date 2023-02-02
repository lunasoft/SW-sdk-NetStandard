using System.Runtime.Serialization;

namespace sw_sdk.Services.Account.AccountBalance
{
    /// <summary>
    /// Estructura del body del servicio Balance Management
    /// </summary>
    [DataContract]
    class AccountBalanceRequest
    {
        [DataMember]
        public string comment { get; set; }
    }
}
