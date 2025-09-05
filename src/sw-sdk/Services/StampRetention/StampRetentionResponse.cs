using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.StampRetention
{
    public class StampRetentionResponseV3 : Response
    {
        [DataMember]
        public DataCfdi Data { get; set; }
    }
    public class DataCfdi
    {
        [DataMember]
        public string Retencion { get; set; }
    }
}
