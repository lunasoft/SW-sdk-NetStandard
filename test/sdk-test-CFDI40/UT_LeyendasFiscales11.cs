using Xunit;
using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW
{
    public class UT_LeyendasFiscales11
    {
        Test_SW.Helpers.StampService stampService = new Test_SW.Helpers.StampService();

        #region Timbrado Versión 1
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con complemento leyendas fiscales mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_LeyendasFiscales_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/LeyendasFiscales11/Cfdi40_LeyendasFiscales.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        #endregion

        #region Timbrado Versión 2
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con complemento leyendas fiscales mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_LeyendasFiscales_StampV2_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/LeyendasFiscales11/Cfdi40_LeyendasFiscales.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        #endregion

        #region Timbrado Versión 4
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con complemento leyendas fiscales mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_LeyendasFiscales_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/LeyendasFiscales11/Cfdi40_LeyendasFiscales.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        #endregion

        #region Timbrado Versión 4 enviando Json
        /// <summary>
        /// Timbrado de Cfdi versión 4.0 de tipo ingreso con complemento leyendas fiscales mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_Cfdi40_LeyendasFiscales_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/LeyendasFiscales11/Cfdi40_LeyendasFiscales.json", "IssueJsonV4");
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