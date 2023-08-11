using Xunit;
using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW
{
    public class UT_CFD40
    {
        Test_SW.Helpers.StampService stampService = new Test_SW.Helpers.StampService();
        Test_SW.Helpers.StampService stampServiceToken = new Test_SW.Helpers.StampService(true);

        #region Timbrado Versión 1
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CFDI40/CFDI40_Ingreso.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo parte mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante Token con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_KitParte_StampV1_Token_ResponseV2()
        {
            var response = (StampResponseV2)await stampServiceToken.StampResponseV2("Resources/CFDI40/CFDI40_Ingreso_KitParte.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo ACuentaTerceros mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_ACuentaTerceros_StampV1_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CFDI40/CFDI40_Ingreso_ACuentaTerceros.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_Global_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_Global.xml", "V1");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global extranjero mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante Token con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_GlobalExtranjero_StampV1_Token_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_GlobalExtranjero.xml", "V1");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo egreso mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_NotaDeCredito_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Egreso_NotaDeCredito.xml", "V1");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo traslado mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_Traslado_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Traslado.xml", "V1");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        #endregion

        #region Timbrado Versión 2
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_StampV2_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CFDI40/CFDI40_Ingreso.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo parte mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante Token con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_KitParte_StampV2_Token_ResponseV2()
        {
            var response = (StampResponseV2)await stampServiceToken.StampResponseV2("Resources/CFDI40/CFDI40_Ingreso_KitParte.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo ACuentaTerceros mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_ACuentaTerceros_StampV2_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CFDI40/CFDI40_Ingreso_ACuentaTerceros.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_Global_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_Global.xml", "V2");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global extranjero mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante Token con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_GlobalExtranjero_StampV2_Token_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_GlobalExtranjero.xml", "V2");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo egreso mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_NotaDeCredito_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Egreso_NotaDeCredito.xml", "V2");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo traslado mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_Traslado_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Traslado.xml", "V2");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        #endregion

        #region Timbrado Versión 4
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_StampV4_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CFDI40/CFDI40_Ingreso.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo parte mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante Token con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_KitParte_StampV4_Token_ResponseV2()
        {
            var response = (StampResponseV2)await stampServiceToken.StampResponseV2("Resources/CFDI40/CFDI40_Ingreso_KitParte.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo ACuentaTerceros mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_ACuentaTerceros_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CFDI40/CFDI40_Ingreso_ACuentaTerceros.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_Global_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_Global.xml", "V4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global extranjero mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante Token con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_GlobalExtranjero_StampV4_Token_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_GlobalExtranjero.xml", "V4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo egreso mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_NotaDeCredito_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Egreso_NotaDeCredito.xml", "V4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo traslado mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_Traslado_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Traslado.xml", "V4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        #endregion

        #region Timbrado Versión 4 enviando Json
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_StampV4Json_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/CFDI40/CFDI40_Ingreso.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo parte mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante Token con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_KitParte_StampV4Json_Token_ResponseV2()
        {
            var response = (StampResponseV2)await stampServiceToken.StampResponseV2("Resources/CFDI40/CFDI40_Ingreso_KitParte.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con nodo ACuentaTerceros mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_ACuentaTerceros_StampV4Json_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/CFDI40/CFDI40_Ingreso_ACuentaTerceros.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_Global_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_Global.json", "IssueJsonV4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso global extranjero mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante Token con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Ingreso_GlobalExtranjero_StampV4Json_Token_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Ingreso_GlobalExtranjero.json", "IssueJsonV4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo egreso mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_NotaDeCredito_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Egreso_NotaDeCredito.json", "IssueJsonV4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo traslado mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contrasena con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Egreso_Traslado_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampServiceToken.StampResponseV4("Resources/CFDI40/CFDI40_Traslado.json", "IssueJsonV4");
            Assert.True(response.Status == "success", response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        #endregion
    }
}
