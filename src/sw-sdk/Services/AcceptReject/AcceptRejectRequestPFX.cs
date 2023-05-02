using System.Runtime.Serialization;

namespace SW.Services.AcceptReject
{
    [DataContract]
    internal class AcceptRejectRequestPFX
    {
        [DataMember]
        internal string Uuid { get; set; }
        [DataMember]
        internal AceptacionRechazoItem[] Uuids { get; set; }
        [DataMember]
        internal string Password { get; set; }
        [DataMember]
        internal string Rfc { get; set; }
        [DataMember]
        internal string B64Pfx { get; set; }        
    }
}
