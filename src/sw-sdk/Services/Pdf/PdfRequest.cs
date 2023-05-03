using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.Pdf
{
    [DataContract]
    internal class PdfRequest
    {
        [DataMember]
        public string XmlContent { get; set; }
        [DataMember]
        public string Logo { get; set; }
        [DataMember]
        public Dictionary<string, string> Extras { get; set; }
        [DataMember]
        public string TemplateId { get; set; }
    }
}
