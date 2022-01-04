﻿using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    [DataContract]
    public class CancelationRequestCSD
    {
        [DataMember]
        public string uuid { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string rfc { get; set; }
        [DataMember]
        public string b64Cer { get; set; }
        [DataMember]
        public string b64Key { get; set; }
        [DataMember]
        public string motivo { get; set; }
        [DataMember]
        public string folioSustitucion { get; set; }
    }
}
