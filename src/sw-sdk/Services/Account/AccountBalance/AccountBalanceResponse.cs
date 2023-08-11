using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Account.AccountBalance
{
    /// <summary>
    /// Estructura de la respuesta que se obtiene en los metodos Añadir y Eliminar timbres
    /// </summary>
    public class AccountBalanceResponse : Response
    {
        [DataMember]
        public string Data { get; set; }
    }
    /// <summary>
    /// Estructura de la respuesta que se obtiene del metodo Balance
    /// </summary>
    public class BalanceResponse : Response
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
