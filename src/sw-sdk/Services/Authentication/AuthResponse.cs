using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Authentication
{
    public class AuthResponse : Response
    {
        [DataMember]
        public Data Data { get; set; }
    }
    public class Data
    {
        [DataMember]
        public string Token { get; set; }
    }
}