using SW.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.Csd
{
    public class CsdResponse : Response
    {
        [DataMember(Name = "data")]
        public string data { get; set; }
    }
    public class GetCsdResponse : Response
    {
        [DataMember]
        public CsdData data { get; set; }
    }
    public class AllCsdResponse : Response
    {
        [DataMember]
        public List<CsdData> data { get; set; }
    }
    [DataContract]
    public class CsdData
    {
        [DataMember]
        public string issuer_rfc { get; set; }
        [DataMember]
        public string certificate_number { get; set; }
        [DataMember]
        public string csd_certificate { get; set; }
        [DataMember]
        public bool is_active { get; set; }
        [DataMember]
        public string issuer_business_name { get; set; }
        [DataMember]
        public string valid_from { get; set; }
        [DataMember]
        public string valid_to { get; set;}
        [DataMember]
        public string certificate_type { get; set; }
    }
}