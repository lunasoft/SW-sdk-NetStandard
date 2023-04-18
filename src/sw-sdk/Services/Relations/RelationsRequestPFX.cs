using System.Runtime.Serialization;

namespace SW.Services.Relations
{
    [DataContract]
    internal class RelationsRequestPFX
    {
        [DataMember]
        internal string _uuid { get; set; }
        [DataMember]
        internal string _password { get; set; }
        [DataMember]
        internal string _rfc { get; set; }
        [DataMember]
        internal string _b64Pfx { get; set; }
    }
}
