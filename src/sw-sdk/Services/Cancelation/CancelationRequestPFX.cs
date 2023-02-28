using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    [DataContract]
    internal class CancelationRequestPFX
    {
        [DataMember]
        internal string uuid { get; set; }
        [DataMember]
        internal string password { get; set; }
        [DataMember]
        internal string rfc { get; set; }
        [DataMember]
        internal string b64Pfx { get; set; }
        [DataMember]
        internal string motivo { get; set; }
        [DataMember]
        internal string folioSustitucion { get; set; }
    }
}
