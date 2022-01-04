﻿using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    [DataContract]
    public class CancelationRequestPFX
    {
        [DataMember]
        public string uuid { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string rfc { get; set; }
        [DataMember]
        public string b64Pfx { get; set; }
        [DataMember]
        public string motivo { get; set; }
        [DataMember]
        public string folioSustitucion { get; set; }
    }
}
