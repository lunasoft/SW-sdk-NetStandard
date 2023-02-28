using System.Runtime.Serialization;

namespace SW.Services.AcceptReject
{
    [DataContract]
    internal class AcceptRejectRequestPFX
    {
        [DataMember]
        internal string uuid { get; set; }
        [DataMember]
        internal AceptacionRechazoItem[] uuids { get; set; }
        [DataMember]
        internal string password { get; set; }
        [DataMember]
        internal string rfc { get; set; }
        [DataMember]
        internal string b64Pfx { get; set; }        
    }
}
