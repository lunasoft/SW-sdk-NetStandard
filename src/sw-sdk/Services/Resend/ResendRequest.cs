using System.Runtime.Serialization;

namespace SW.Services.Resend
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
