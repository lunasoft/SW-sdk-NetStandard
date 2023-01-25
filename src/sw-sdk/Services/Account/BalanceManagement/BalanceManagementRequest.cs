using System.Runtime.Serialization;

namespace sw_sdk.Services.Account.BalanceManagement
{
    /// <summary>
    /// Estructura del body del servicio Balance Management
    /// </summary>
    [DataContract]
    class BalanceManagementRequest
    {
         
        [DataMember]
        public string comment { get; set; }
    }

}
