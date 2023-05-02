using System.Runtime.Serialization;

namespace SW.Services.Relations
{
    [DataContract]
    internal class RelationsRequestCSD
    {
        [DataMember]
        internal string Uuid { get; set; }
        [DataMember]
        internal string Password { get; set; }
        [DataMember]
        internal string Rfc { get; set; }
        [DataMember]
        internal string B64Cer { get; set; }
        [DataMember]
        internal string B64Key { get; set; }
    }
}
