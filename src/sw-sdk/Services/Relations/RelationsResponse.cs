using SW.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.Relations
{
    public class RelationsResponse : Response
    {
        [DataMember(Name = "data")]
        public Data Data { get; set; }
        [DataMember]
        public string CodStatus { get; set; }
    }
    public class Data
    {
        [DataMember]
        public Guid UuidConsultado { get; set; }
        [DataMember]
        public string Resultado { get; set; }
        [DataMember]
        public List<InvoicesStatus> UuidsRelacionadosPadres { get; set; }
        [DataMember]
        public List<InvoicesStatus> UuidsRelacionadosHijos { get; set; }
    }

    public class InvoicesStatus
    {
        public Guid Uuid { get; set; }
        public string RfcEmisor { get; set; }
        public string RfcReceptor { get; set; }
    }
}
