using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    [DataContract]
    internal class CancelationRequestPFX
    {
        [DataMember]
        internal string Uuid { get; set; }
        [DataMember]
        internal string Password { get; set; }
        [DataMember]
        internal string Rfc { get; set; }
        [DataMember]
        internal string B64Pfx { get; set; }
        [DataMember]
        internal string Motivo { get; set; }
        [DataMember]
        internal string Foliosustitucion { get; set; }
    }
}
