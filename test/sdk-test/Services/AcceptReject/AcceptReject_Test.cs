using System;
using SW.Helpers;
using Test_SW.Helpers;
using SW.Services.AcceptReject;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using System.IO;
using Test_SW.Helper;

namespace Test_SW.Services.AcceptReject_Test
{
    public class AcceptReject_Test
    {
        private BuildSettings build;
        public AcceptReject_Test()
        {
            build = new BuildSettings();
        }
        /// <summary>
        /// Valida los parametros para la aceptacion o rechazo por CSD.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ValidateParametersAsync()
        {
            var resultExpect = "El uuid proporcionado es inválido. Favor de verificar";
            AcceptReject acceptReject = new AcceptReject(build.Url, build.User, build.Password);
            AcceptRejectResponse response = await acceptReject.AcceptByCSD(build.Cer, build.Key, build.Rfc, build.CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { Uuid = "" } });
            Assert.Contains((string)resultExpect, response.MessageDetail);
        }
        /// <summary>
        /// Aceptacion o Rechazo por UUID
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task AcceptRejectByRfcUuidAsync()
        {
            AcceptReject acceptReject = new AcceptReject(build.Url, build.User, build.Password);
            var response = await acceptReject.AcceptByRfcUuid(build.RfcReceptor, "DB68450F-355B-4915-AFDC-A980497C4D70", EnumAcceptReject.Aceptacion);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.True(response.Data.Folios.Count > 0);
        }
        /// <summary>
        /// Aceptacion o Rechazo por CSD
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task AcceptRejectByCSDAsync()
        {
            AcceptReject acceptReject = new AcceptReject(build.Url, build.User, build.Password);
            var response = await acceptReject.AcceptByCSD(build.CerReceptor, build.KeyReceptor, build.RfcReceptor, build.CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { Uuid = "DB68450F-355B-4915-AFDC-A980497C4D70", action = EnumAcceptReject.Aceptacion } });
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.True(response.Data.Folios.Count > 0);
        }
        /// <summary>
        /// Aceptacion o Rechazo por PFX
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task AcceptRejectByPfxAsync()
        {
            AcceptReject acceptReject = new AcceptReject(build.Url, build.User, build.Password);
            var response = await acceptReject.AcceptByPFX(build.PfxReceptor, build.RfcReceptor, build.CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { Uuid = "DB68450F-355B-4915-AFDC-A980497C4D70", action = EnumAcceptReject.Aceptacion } });
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.True(response.Data.Folios.Count > 0);
        }
        /// <summary>
        /// Aceptacion o Rechazo por XML
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task AcceptRejectByXmlAsync()
        {
            AcceptReject acceptReject = new AcceptReject(build.Url, build.User, build.Password);
            var xml = File.ReadAllText("Resources/aceptacionRechazo.xml");
            var response = await acceptReject.AcceptByXML(Encoding.UTF8.GetBytes(xml));
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.True(response.Data.Folios.Count > 0);
        }
    }
}
