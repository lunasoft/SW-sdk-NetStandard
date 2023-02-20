using System.Runtime.Serialization;

namespace SW.Services.Relations
{
    [DataContract]
    internal class RelationsRequestCSD
    {
        [DataMember]
        internal string uuid { get; set; }
        [DataMember]
        internal string password { get; set; }
        [DataMember]
        internal string rfc { get; set; }
        [DataMember]
        internal string b64Cer { get; set; }
        [DataMember]
        internal string b64Key { get; set; }
    }
}
