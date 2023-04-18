using System;
using System.Runtime.Serialization;
using SW.Entities;

namespace SW.Services.Pdf
{
    [DataContract]
    public class PdfResponse : Response
    {
        [DataMember(Name = "data")]
        public Data Data { get; set; }
        [DataMember]
        public int ResponseCode { get; set; }
    }

    public class Data
    {
        [DataMember]
        public string ContentB64 { get; set; }
        [DataMember]
        public int ContentSizeBytes { get; set; }
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public string Folio { get; set; }
        [DataMember]
        public DateTime StampDate { get; set; }
        [DataMember]
        public DateTime IssuedDate { get; set; }
        [DataMember]
        public string RfcIssuer { get; set; }
        [DataMember]
        public string RfcReceptor { get; set; }
        [DataMember]
        public string Total { get; set; }
    }
}
