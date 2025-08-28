using SW.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.CancelationRetention
{
    public class CancelationRetResponse : Response
    {
        [DataMember(Name = "data")]
        public Data Data { get; set; }
    }
    public class Data
    {
        [DataMember(Name = "acuse")]
        public string Acuse { get; set; }
        [DataMember]
        public Dictionary<string, string> Uuid { get; set; }
    }
}
