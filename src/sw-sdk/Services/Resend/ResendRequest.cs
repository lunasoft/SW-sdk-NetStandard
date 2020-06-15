using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace sw_sdk.Services.Resend
{
    [DataContract]
    public class ResendRequest
    {
        [DataMember]
        public string uuid { get; set; }
        [DataMember]
        public string to { get; set; }
    }
}
