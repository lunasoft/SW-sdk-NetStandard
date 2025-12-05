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
        public string IdUserBalance { get; set; }
        [DataMember]
        public string IdUser { get; set; }
        [DataMember]
        public int StampsBalance { get; set; }
        [DataMember]
        public int StampsUsed { get; set; }
        [DataMember]
        public string ExpirationDate { get; set; }
        [DataMember]
        public bool Unlimited { get; set; }
        [DataMember]
        public int StampsAssigned { get; set; }
        [DataMember]
        public AccountLastTransaction LastTransaction { get; set; }
    }
    [DataContract]
    public class AccountLastTransaction
    {
        [DataMember]
        public int Folio { get; set; }
        [DataMember]
        public string IdUSer { get; set; }
        [DataMember]
        public string IdUserReceiver { get; set; }
        [DataMember]
        public string NameReceiver { get; set; }
        [DataMember]
        public int? StampsIn { get; set; }
        [DataMember]
        public int? StampsOut { get; set; }
        [DataMember]
        public int StampsCurrent { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public bool IsEmailSent { get; set; }
    }
}
