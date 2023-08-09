using System.Runtime.Serialization;

namespace SW.Entities
{
    /// <summary>
    /// Representa un objeto de respuesta que puede contener información 
    /// de estado, mensaje y detalles del mensaje.
    /// </summary>
    [DataContract]
    public class Response
    {
        [DataMember]
        public string Status { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public string MessageDetail { get; private set; }

        /// <summary>
        /// Establece el estado de la respuesta.
        /// </summary>
        /// <param name="value">Estado a establecer.</param>
        internal void SetStatus(string value)
        {
            Status = value;
        }

        /// <summary>
        /// Establece el mensaje de la respuesta.
        /// </summary>
        /// <param name="value">Mensaje a establecer.</param>
        internal void SetMessage(string value)
        {
            Message = value;
        }

        /// <summary>
        /// Establece el detalle del mensaje de la respuesta.
        /// </summary>
        /// <param name="value">Detalle a establecer.</param>
        internal void SetMessageDetail(string value)
        {
            MessageDetail = value;
        }
    }
}