using SW.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.Csd
{
    public class CsdResponse : Response
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
    public class GetCsdResponse : Response
    {
        [DataMember]
        public CsdData Data { get; set; }
    }
    public class AllCsdResponse : Response
    {
        [DataMember]
        public List<CsdData> Data { get; set; }
    }
    [DataContract]
    public class CsdData
    {
        [DataMember]
        public string IssuerRfc { get; set; }
        [DataMember]
        public string CertificateNumber { get; set; }
        [DataMember]
        public string CsdCertificate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string IssuerBusinessName { get; set; }
        [DataMember]
        public string ValidFrom { get; set; }
        [DataMember]
        public string ValidTo { get; set;}
        [DataMember]
        public string CertificateType { get; set; }
    }
}