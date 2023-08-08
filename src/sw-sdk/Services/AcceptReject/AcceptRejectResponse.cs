using System.Collections.Generic;
using SW.Entities;
using System.Runtime.Serialization;
using System;

namespace SW.Services.AcceptReject
{
    public class AcceptRejectResponse : Response
    {
        [DataMember(Name = "data")]
        public Data Data { get; set; }
        [DataMember(Name = "codStatus")]
        public string CodStatus { get; set; }
    }
    public class Data
    {
        [DataMember(Name = "acuse")]
        public string Acuse { get; set; }
        [DataMember(Name = "folios")]
        public List<invoicesStatus> Folios { get; set; }
    }
    public class invoicesStatus
    {
        public Guid Uuid { get; set; }
        public string EstatusUuid { get; set; }
        public string Respuesta { get; set; }
    }
}