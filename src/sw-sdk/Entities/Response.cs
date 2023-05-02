using System.Runtime.Serialization;

namespace SW.Entities
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string MessageDetail { get; set; }
    }
}