using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Csd
{
    public class UploadCsdResponse : Response
    {
        [DataMember(Name = "data")]
        public string data { get; set; }
    }
}