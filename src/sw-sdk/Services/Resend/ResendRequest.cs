using System.Runtime.Serialization;

namespace SW.Services.Resend
{
    [DataContract]
    public class ResendRequest
    {
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string To { get; set; }
    }
}
