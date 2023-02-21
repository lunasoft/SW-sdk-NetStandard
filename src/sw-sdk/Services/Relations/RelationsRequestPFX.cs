using System.Runtime.Serialization;

namespace SW.Services.Relations
{
    [DataContract]
    internal class RelationsRequestPFX
    {
        [DataMember]
        internal string uuid { get; set; }
        [DataMember]
        internal string password { get; set; }
        [DataMember]
        internal string rfc { get; set; }
        [DataMember]
        internal string b64Pfx { get; set; }
    }
}
