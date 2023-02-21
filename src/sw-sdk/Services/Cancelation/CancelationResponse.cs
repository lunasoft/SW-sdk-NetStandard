﻿using System.Collections.Generic;
using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Cancelation
{
    public class CancelationResponse : Response
    {
        [DataMember(Name = "data")]
        public Data data { get; set; }
    }
    public class Data
    {
        [DataMember(Name = "acuse")]
        public string acuse { get; set; }
        [DataMember]
        public Dictionary<string, string> uuid { get; set; }
    }
}