using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    [DataContract]
    internal class CancelationRequestCSD
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
        [DataMember]
        internal string _motivo { get; set; }
        [DataMember]
        internal string _folioSustitucion { get; set; }
    }
}
