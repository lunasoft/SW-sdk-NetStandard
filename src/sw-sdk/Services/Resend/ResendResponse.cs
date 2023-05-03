using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Resend
{
    [DataContract]
    public class ResendResponse : Response
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
