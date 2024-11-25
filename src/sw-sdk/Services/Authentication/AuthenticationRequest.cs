using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace sw_sdk.Services.Authentication
{
    /// <summary>
    /// Estructura del body del servicio AuthenticationV2
    /// </summary>
    [DataContract]
    internal class AuthenticationRequest
    {
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
