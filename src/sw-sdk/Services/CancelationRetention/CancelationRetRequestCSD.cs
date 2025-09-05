using System.Runtime.Serialization;

namespace SW.Services.CancelationRetention
{
    [DataContract]
    internal class CancelationRetRequestCSD
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
        [DataMember]
        internal string Motivo { get; set; }
        [DataMember]
        internal string Foliosustitucion { get; set; }
    }
}
