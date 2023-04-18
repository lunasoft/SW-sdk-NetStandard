using System.Runtime.Serialization;

namespace SW.Services.Account
{
    public class AccountResponse : Entities.Response
    {
        [DataMember]
        public Data Data { get; set; }
        
    }
    public partial class Data
    {
        [DataMember]
        public string IdSaldoCliente { get; set; }
        [DataMember]
        public string IdClienteUsuario { get; set; }
        [DataMember]
        public int SaldoTimbres { get; set; }
        [DataMember]
        public int TimbresUtilizados { get; set; }
        [DataMember]
        public string FechaExpiracion { get; set; }
        [DataMember]
        public bool Unlimited { get; set; }
        [DataMember]
        public int TimbresAsignados { get; set; }
    }
}