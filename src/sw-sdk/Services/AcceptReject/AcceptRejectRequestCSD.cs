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
        internal string uuid { get; set; }
        [DataMember]
        internal AceptacionRechazoItem[] uuids { get; set; }
        [DataMember]
        internal string password { get; set; }
        [DataMember]
        internal string rfc { get; set; }
        [DataMember]
        internal string b64Cer { get; set; }
        [DataMember]
        internal string b64Key { get; set; }
    }
    [DataContract]
    public class AceptacionRechazoItem
    {
        [DataMember]
        public string uuid { get; set; }
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
