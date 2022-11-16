using Xunit;
using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW
{
    public class UT_CartaPorte20
    {
        Test_SW.Helpers.StampService stampService = new Test_SW.Helpers.StampService();

        #region Timbrado Versión 1
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_Autotransporte_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_Autotransporte.xml", "V1");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte ferroviario mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteFerroviario_StampV1_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteFerroviario.xml", "V1");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte aéreo mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteAereo_StampV1_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteAereo.xml", "V1");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte marítimo mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteMaritimo_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteMaritimo.xml", "V1");
            Assert.True(response.status == "success", response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_Autotransporte_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_Autotransporte.xml", "V1");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte ferroviario mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteFerroviario_StampV1_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteFerroviario.xml", "V1");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte aéreo mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteAereo_StampV1_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteAereo.xml", "V1");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte marítimo mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteMaritimo_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteMaritimo.xml", "V1");
            Assert.True(response.status == "success", response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        #endregion
        
        #region Timbrado Versión 2
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_Autotransporte_StampV2_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_Autotransporte.xml", "V2");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte ferroviario mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteFerroviario_StampV2_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteFerroviario.xml", "V2");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte aéreo mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteAereo_StampV2_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteAereo.xml", "V2");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte marítimo mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteMaritimo_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteMaritimo.xml", "V2");
            Assert.True(response.status == "success", response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_Autotransporte_StampV2_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_Autotransporte.xml", "V2");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte ferroviario mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteFerroviario_StampV2_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteFerroviario.xml", "V2");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte aéreo mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteAereo_StampV2_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteAereo.xml", "V2");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte marítimo mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteMaritimo_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteMaritimo.xml", "V2");
            Assert.True(response.status == "success", response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        #endregion
        
        #region Timbrado Versión 4
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_Autotransporte_StampV4_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_Autotransporte.xml", "V4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte ferroviario mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteFerroviario_StampV4_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteFerroviario.xml", "V4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte aéreo mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteAereo_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteAereo.xml", "V4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte marítimo mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteMaritimo_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteMaritimo.xml", "V4");
            Assert.True(response.status == "success", response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_Autotransporte_StampV4_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_Autotransporte.xml", "V4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte ferroviario mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteFerroviario_StampV4_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteFerroviario.xml", "V4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte aéreo mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteAereo_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteAereo.xml", "V4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
                
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo transporte marítimo mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_TransporteMaritimo_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_TransporteMaritimo.xml", "V4");
            Assert.True(response.status == "success", response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        #endregion
        
        #region Timbrado Versión 4 enviando Json
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_Autotransporte_StampV4Json_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_Autotransporte.json", "IssueJsonV4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con complemento carta porte de tipo transporte ferroviario mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Ingreso_CartaPorte_TransporteFerroviario_StampV4Json_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/CartaPorte20/CFDI40_Ingreso_CartaPorte_TransporteFerroviario.json", "IssueJsonV4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
      
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento carta porte de tipo autotransporte mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Traslado_CartaPorte_Autotransporte_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CartaPorte20/CFDI40_Traslado_CartaPorte_Autotransporte.json", "IssueJsonV4");
            Assert.True(response.status == "success", response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        #endregion
    }
}