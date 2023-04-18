using System.Runtime.Serialization;

namespace SW.Services.AcceptReject
{
    [DataContract]
    internal class AcceptRejectRequestPFX
    {
        [DataMember]
        internal string _uuid { get; set; }
        [DataMember]
        internal AceptacionRechazoItem[] _uuids { get; set; }
        [DataMember]
        internal string _password { get; set; }
        [DataMember]
        internal string _rfc { get; set; }
        [DataMember]
        internal string _b64Pfx { get; set; }        
    }
}
