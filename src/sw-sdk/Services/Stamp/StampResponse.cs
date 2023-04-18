using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Stamp
{
    public class StampResponseV1 : Response
    {
        [DataMember]
        public DataTfd Data { get; set; }
    }
    public class StampResponseV2 : Response
    {
        [DataMember]
        public DataCfdiTfd Data { get; set; }
    }
    public class StampResponseV3 : Response
    {
        [DataMember]
        public DataCfdi Data { get; set; }
    }

    public class StampResponseV4 : Response
    {
        [DataMember]
        public DataComplete Data { get; set; }
    }
    public class DataTfd
    {
        [DataMember]
        public string Tfd { get; set; }
    }

    public class DataCfdi
    {
        [DataMember]
        public string Cfdi { get; set; }
    }

    public class DataCfdiTfd : DataTfd
    {
        [DataMember]
        public string Cfdi { get; set; }
    }

    public class DataComplete : DataCfdi
    {
        [DataMember]
        public string CadenaOriginalSat { get; set; }
        [DataMember]
        public string NoCertificadoSat { get; set; }
        [DataMember]
        public string NoCertificadoCfdi { get; set; }
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string SelloSat { get; set; }
        [DataMember]
        public string SelloCfdi { get; set; }
        [DataMember]
        public string FechaTimbrado { get; set; }
        [DataMember]
        public string QrCode { get; set; }
    }
}