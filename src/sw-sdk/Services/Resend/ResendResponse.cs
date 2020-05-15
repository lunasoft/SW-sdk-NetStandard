using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace sw_sdk.Services.Resend
{
    [DataContract]
    public class ResendResponse : SW.Entities.Response
    {
        [DataMember]
        public string status { get; set; }
        [DataMember(Name = "data")]
        public string data { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string messageDetail { get; set; }
    }
}
