using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    [DataContract]
    internal class CancelationRequestPFX
    {
        [DataMember]
        internal string _uuid { get; set; }
        [DataMember]
        internal string _password { get; set; }
        [DataMember]
        internal string _rfc { get; set; }
        [DataMember]
        internal string _b64Pfx { get; set; }
        [DataMember]
        internal string _motivo { get; set; }
        [DataMember]
        internal string _folioSustitucion { get; set; }
    }
}
