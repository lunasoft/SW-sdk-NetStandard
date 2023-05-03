using SW.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.Pendings
{
    public class PendingsResponse : Response
    {        
        [DataMember(Name = "data")]
        public Data Data { get; set; }
        [DataMember]
        public string CodStatus { get; set; }
    }
    public class Data
    {
        [DataMember]
        public string CodEstatus { get; set; }
        [DataMember]
        public List<string> Uuid { get; set; }
    }
}

