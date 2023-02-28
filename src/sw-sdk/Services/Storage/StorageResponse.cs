using SW.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SW.Services.Storage
{
    [DataContract]
    public class StorageResponse : Response
    {
        [DataMember]
        public StorageData data { get; set; }
    }
    public class StorageData
    {
        [DataMember]
        public List<StorageRecords> records { get; set; }
    }
    public class StorageRecords
    {
        [DataMember]
        public string urlXml { get; set; }
        [DataMember]
        public string urlPdf { get; set; }
        [DataMember]
        public string urlAckCfdi { get; set; }
        [DataMember]
        public string urlAckCancellation { get; set; }
        [DataMember]
        public string urlAddenda { get; set; }
    }

    [DataContract]
    public class StorageExtraResponse : Response
    {
        [DataMember]
        public StorageExtraData data { get; set; }
    }
    public class StorageExtraData
    {
        public List<StorageExtraRecords> records { get; set; }
    }

    public class StorageExtraRecords : StorageRecords
    {
        [DataMember]
        public bool status { get; set; }
        [DataMember]
        public string fechaGeneracionPdf { get; set; }
        [DataMember]
        public string idDealer { get; set; }
        [DataMember]
        public string idUser { get; set; }
        [DataMember]
        public string version { get; set; }
        [DataMember]
        public string serie { get; set; }
        [DataMember]
        public string folio { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public string numeroCertificado { get; set; }
        [DataMember]
        public decimal subTotal { get; set; }
        [DataMember]
        public decimal descuento { get; set; }
        [DataMember]
        public decimal total { get; set; }
        [DataMember]
        public string moneda { get; set; }
        [DataMember]
        public decimal tipoCambio { get; set; }
        [DataMember]
        public string tipoDeComprobante { get; set; }
        [DataMember]
        public string metodoPago { get; set; }
        [DataMember]
        public string formaPago { get; set; }
        [DataMember]
        public string condicionesPago { get; set; }
        [DataMember]
        public string luegarExpedicion { get; set; }
        [DataMember]
        public string emisorRfc { get; set; }
        [DataMember]
        public string emisorNombre { get; set; }
        [DataMember]
        public string regimenFiscal { get; set; }
        [DataMember]
        public string receptorRfc { get; set; }
        [DataMember]
        public string receptorNombre { get; set; }
        [DataMember]
        public string residenciaFiscal { get; set; }
        [DataMember]
        public string numRegIdTrib { get; set; }
        [DataMember]
        public string usoCFDI { get; set; }
        [DataMember]
        public decimal totalImpuestosTraslados { get; set; }
        [DataMember]
        public decimal totalImpuestosRetencion { get; set; }
        [DataMember]
        public decimal trasladosIVA { get; set; }
        [DataMember]
        public decimal trasladosIEPS { get; set; }
        [DataMember]
        public decimal retencionesISR { get; set; }
        [DataMember]
        public decimal retencionesIVA { get; set; }
        [DataMember]
        public decimal retencionesIEPS { get; set; }
        [DataMember]
        public decimal totalImpuestosLocalesTraslados { get; set; }
        [DataMember]
        public decimal totalImpuestosLocalesRetencion { get; set; }
        [DataMember]
        public string complementos { get; set; }
        [DataMember]
        public string uuid { get; set; }
        [DataMember]
        public string fechaTimbrado { get; set; }
        [DataMember]
        public string rfcProvCertif { get; set; }
        [DataMember]
        public string selloCFD { get; set; }
    }
}