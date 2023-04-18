using System.Collections.Generic;
using System.Runtime.Serialization;
using SW.Entities;

namespace SW.Services.Validate
{
    public class ValidateXmlResponse : Response
    {
        [DataMember]
        public List<Detail> Detail { get; set; }
        [DataMember]
        public string CadenaOriginalSAT { get; set; }
        [DataMember]
        public string CadenaOriginalComprobante { get; set; }
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string StatusSat { get; set; }
        [DataMember]
        public string StatusCodeSat { get; set; }
    }
    public class Detail
    {
        [DataMember]
        public List<DetailNode> detail { get; set; }
        [DataMember]
        public string Section { get; set; }
    }
    public class DetailNode
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string MessageDetail { get; set; }
        [DataMember]
        public int Type { get; set; }
    }
}
