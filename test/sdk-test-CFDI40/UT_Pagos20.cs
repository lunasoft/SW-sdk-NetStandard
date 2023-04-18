using Xunit;
using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW
{
    public class UT_Pagos20
    {
        Test_SW.Helpers.StampService stampService = new Test_SW.Helpers.StampService();

        #region Timbrado Versión 1
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Pagos20/Cfdi40_Pago.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en USD y monda del documento relacionado en MXN mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_Dolar_StampV1_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Pagos20/Cfdi40_Pago_Dolar.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en MXN y monda del documento relacionado en USD mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_DoctoRelacionadoEnDolar_StampV1_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Pagos20/Cfdi40_Pago_DoctoRelacionadoEnDolar.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en EUR y monda del documento relacionado en USD mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_EURyDRenUSD_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_EURyDRenUSD.xml", "V1");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago con dos monedas de pago distintas y monda del documento relacionado en USD mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact(Skip = "Skip por error de en el documento")]
        public async Task UT_Cfdi40_Pago_MonedasDistintasyDRenUSD_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_MonedasDistintasyDRenUSD.xml", "V1");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago con con Factoraje mediante el servicio de timbrado versión 1 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_Factoraje_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_Factoraje.xml", "V1");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_StampV2_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Pagos20/Cfdi40_Pago.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en USD y monda del documento relacionado en MXN mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_Dolar_StampV2_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Pagos20/Cfdi40_Pago_Dolar.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en MXN y monda del documento relacionado en USD mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_DoctoRelacionadoEnDolar_StampV2_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Pagos20/Cfdi40_Pago_DoctoRelacionadoEnDolar.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en EUR y monda del documento relacionado en USD mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_EURyDRenUSD_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_EURyDRenUSD.xml", "V2");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago con dos monedas de pago distintas y monda del documento relacionado en USD mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact(Skip = "Skip por error de en el documento")]
        public async Task UT_Cfdi40_Pago_MonedasDistintasyDRenUSD_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_MonedasDistintasyDRenUSD.xml", "V2");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago con con Factoraje mediante el servicio de timbrado versión 2 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_Factoraje_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_Factoraje.xml", "V2");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_StampV4_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Pagos20/Cfdi40_Pago.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en USD y monda del documento relacionado en MXN mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_Dolar_StampV4_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Pagos20/Cfdi40_Pago_Dolar.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en MXN y monda del documento relacionado en USD mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_DoctoRelacionadoEnDolar_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Pagos20/Cfdi40_Pago_DoctoRelacionadoEnDolar.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en EUR y monda del documento relacionado en USD mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_EURyDRenUSD_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_EURyDRenUSD.xml", "V4");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago con dos monedas de pago distintas y monda del documento relacionado en USD mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact(Skip = "Skip por error de en el documento")]
        public async Task UT_Cfdi40_Pago_MonedasDistintasyDRenUSD_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_MonedasDistintasyDRenUSD.xml", "V4");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago con con Factoraje mediante el servicio de timbrado versión 4 de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_Factoraje_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_Factoraje.xml", "V4");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_StampV4Json_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Pagos20/Cfdi40_Pago.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en USD y monda del documento relacionado en MXN mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_Dolar_StampV4Json_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Pagos20/Cfdi40_Pago_Dolar.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }

        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo pago con moneda de pago en EUR y monda del documento relacionado en USD mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_Pago_EURyDRenUSD_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_EURyDRenUSD.json", "IssueJsonV4");
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
        /// Timbrado de Cfdi versión 4.0 de tipo pago con dos monedas de pago distintas y monda del documento relacionado en USD mediante el servicio de timbrado versión 4 (Json) de la libreria sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact(Skip = "Skip por error de en el JSON")]
        public async Task UT_Cfdi40_Pago_MonedasDistintasyDRenUSD_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Pagos20/Cfdi40_Pago_MonedasDistintasyDRenUSD.json", "IssueJsonV4");
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
