using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SW.Helpers;
using System.Runtime.Serialization;

namespace SW.Services.AcceptReject
{
    [DataContract]
    internal class AcceptRejectRequestCSD
    {
        [DataMember]
        internal string Uuid { get; set; }
        [DataMember]
        internal AceptacionRechazoItem[] Uuids { get; set; }
        [DataMember]
        internal string Password { get; set; }
        [DataMember]
        internal string Rfc { get; set; }
        [DataMember]
        internal string B64Cer { get; set; }
        [DataMember]
        internal string B64Key { get; set; }
    }
    [DataContract]
    public class AceptacionRechazoItem
    {
        [DataMember]
        public string Uuid { get; set; }
        private EnumAcceptReject _action;

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumAcceptReject action
        {
            get { return _action; }
            set { _action = value; }
        }

    }
}
