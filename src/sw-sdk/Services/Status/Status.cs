using ExternalServices.ConsultaCFDIService;

namespace SW.Services.Status
{
    public class Status : StatusService
    {
        /// <summary>
        /// Crear una instancia de la clase Status.
        /// </summary>
        /// <remarks>Incluye método para la consulta de estatus de un comprobante timbrado.</remarks>
        /// <param name="url">Url Consulta SAT.</param>
        /// <param name="receiveTimeoutInSeconds">Especifica un timeout para el request. Default: 60 segundos.</param>
        public Status(string url, int receiveTimeoutInSeconds = 60) : base(url, receiveTimeoutInSeconds)
        {
        }
        internal override Acuse StatusRequest(string rfcEmisor, string rfcReceptor, string total, string uuid, string sello)
        {
            return this.RequestStatus(rfcEmisor, rfcReceptor, total, uuid, sello);
        }
        /// <summary>
        /// Servicio de consulta de estatus en el SAT de un CFDI timbrado.
        /// </summary>
        /// <param name="rfcEmisor">RFC del emisor.</param>
        /// <param name="rfcReceptor">RFC del receptor.</param>
        /// <param name="total">Total del CFDI.</param>
        /// <param name="uuid">Folio fiscal del CFDI timbrado.</param>
        /// <param name="sello">Ultimos ocho dígitos del sello del comprobante.</param>
        /// <returns><see cref="Acuse"/></returns>
        public Acuse GetStatusCFDI(string rfcEmisor, string rfcReceptor, string total, string uuid, string sello)
        {
            return StatusRequest(rfcEmisor, rfcReceptor, total, uuid, sello);
        }
    }
}
