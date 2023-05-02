using System.Runtime.Serialization;

namespace SW.Services.Relations
{
    [DataContract]
    internal class RelationsRequestPFX
    {
        [DataMember]
        internal string Uuid { get; set; }
        [DataMember]
        internal string Password { get; set; }
        [DataMember]
        internal string Rfc { get; set; }
        [DataMember]
        internal string B64Pfx { get; set; }
    }
}
