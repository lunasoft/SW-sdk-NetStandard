using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.Pdf
{
    [DataContract]
    internal class PdfRequest
    {
        [DataMember]
        internal string xmlContent { get; set; }
        [DataMember]
        internal string logo { get; set; }
        [DataMember]
        internal Dictionary<string, string> extras { get; set; }
        [DataMember]
        internal string templateId { get; set; }
    }
}
