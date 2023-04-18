using System.Runtime.Serialization;

namespace SW.Services.Relations
{
    [DataContract]
    internal class RelationsRequestCSD
    {
        [DataMember]
        internal string _uuid { get; set; }
        [DataMember]
        internal string _password { get; set; }
        [DataMember]
        internal string _rfc { get; set; }
        [DataMember]
        internal string _b64Cer { get; set; }
        [DataMember]
        internal string _b64Key { get; set; }
    }
}
