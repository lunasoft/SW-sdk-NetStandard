using Xunit;
using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW
{
    public class UT_Addenda
    {
        Test_SW.Helpers.StampService stampService = new Test_SW.Helpers.StampService();

        #region Timbrado Versión 1
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con Addenda mediante el servicio de timbrado versión 1 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 1
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Detallista_StampV1_ResponseV1()
        {
            var response = (StampResponseV1)await stampService.StampResponseV1("Resources/Addenda/CFDI40_Addenda.xml", "V1");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }        
        #endregion
        
        #region Timbrado Versión 2
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con Addenda mediante el servicio de timbrado versión 2 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 2
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Detallista_StampV2_ResponseV2()
        {
            var response = (StampResponseV2)await stampService.StampResponseV2("Resources/Addenda/CFDI40_Addenda.xml", "V2");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }        
        #endregion
        
        #region Timbrado Versión 4
        /// <summary>
        /// Timbrado de CFDI versión 4.0 de tipo ingreso con Addenda mediante el servicio de timbrado versión 4 de la librería sw-sdk mediante usuario y contraseña con respuesta versión 3
        /// </summary>
        [Fact]
        public async Task UT_CFDI40_Detallista_StampV4_ResponseV3()
        {
            var response = (StampResponseV3)await stampService.StampResponseV3("Resources/Addenda/CFDI40_Addenda.xml", "V4");
            Assert.True(response.status == "success" && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }        
        #endregion
    }
}
