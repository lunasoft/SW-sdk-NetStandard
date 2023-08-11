using Xunit;
using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW
{
    public class UT_Nomina12
    {
        Test_SW.Helpers.StampService stampService = new Test_SW.Helpers.StampService();

        #region Timbrado Versión 1
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con incapacidades mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Incapacidades_StampV1_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_Incapacidades.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con horas extra mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_HorasExtra_StampV1_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_HorasExtra.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina sin deducciones mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SinDeducciones_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_SinDeducciones.xml", "V1");
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
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina extraordinaria mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Extraordinaria_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina_Extraordinaria.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina separación indemnización mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SeparacionIndemnizacion_StampV1_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_SeparacionIndemnizacion.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV1_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro.xml", "V1");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV1_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro2.xml", "V1");
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
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_StampV2_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con incapacidades mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Incapacidades_StampV2_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_Incapacidades.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con horas extra mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_HorasExtra_StampV2_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_HorasExtra.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina sin deducciones mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SinDeducciones_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_SinDeducciones.xml", "V2");
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
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina extraordinaria mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Extraordinaria_StampV2_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina_Extraordinaria.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina separación indemnización mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SeparacionIndemnizacion_StampV2_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_SeparacionIndemnizacion.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV2_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro.xml", "V2");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV2_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro2.xml", "V2");
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
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_StampV4_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con incapacidades mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Incapacidades_StampV4_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_Incapacidades.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con horas extra mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_HorasExtra_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_HorasExtra.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina sin deducciones mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SinDeducciones_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_SinDeducciones.xml", "V4");
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
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina extraordinaria mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Extraordinaria_StampV4_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina_Extraordinaria.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina separación indemnización mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SeparacionIndemnizacion_StampV4_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_SeparacionIndemnizacion.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro.xml", "V4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV4_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro2.xml", "V4");
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
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_StampV4Json_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con incapacidades mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Incapacidades_StampV4Json_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_Incapacidades.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina con horas extra mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_HorasExtra_StampV4Json_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_HorasExtra.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo nomina con complemento de nómina sin deducciones mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SinDeducciones_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_SinDeducciones.json", "IssueJsonV4");
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
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina extraordinaria mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_Extraordinaria_StampV4Json1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Nomina12/CFDI40_Nomina_Extraordinaria.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina separación indemnización mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_SeparacionIndemnizacion_StampV4Json_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Nomina12/CFDI40_Nomina_SeparacionIndemnizacion.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV4Json_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro.json", "IssueJsonV4");
            Assert.True(response.Status == "success" && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo traslado con complemento de nómina jubilación pensión retiro mediante el servicio de timbrado versión 4 (Json) de la librería sw-sdk mediante usuario y contraseña con respuesta versión 4
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Nomina_JubilacionPensionRetiro_StampV4Json_ResponseV4()
        {
            var response = (StampResponseV4)await stampService.StampResponseV4("Resources/Nomina12/CFDI40_Nomina_JubilacionPensionRetiro2.json", "IssueJsonV4");
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