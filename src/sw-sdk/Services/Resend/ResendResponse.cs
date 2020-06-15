using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace sw_sdk.Services.Resend
{
    [DataContract]
    public class ResendResponse : SW.Entities.Response
    {
        [DataMember(Name = "data")]
        public string data { get; set; }
    }
}
