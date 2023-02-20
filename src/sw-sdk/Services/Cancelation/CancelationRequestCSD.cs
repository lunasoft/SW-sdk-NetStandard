using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    [DataContract]
    internal class CancelationRequestCSD
    {
        [DataMember]
        internal string uuid { get; set; }
        [DataMember]
        internal string password { get; set; }
        [DataMember]
        internal string rfc { get; set; }
        [DataMember]
        internal string b64Cer { get; set; }
        [DataMember]
        internal string b64Key { get; set; }
        [DataMember]
        internal string motivo { get; set; }
        [DataMember]
        internal string folioSustitucion { get; set; }
    }
}
