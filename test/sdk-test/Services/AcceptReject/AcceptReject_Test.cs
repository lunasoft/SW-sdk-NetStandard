using System;
using System.Diagnostics;
using SW.Helpers;
using Test_SW.Helpers;
using SW.Services.AcceptReject;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using System.IO;

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
            AcceptRejectResponse response = await acceptReject.AcceptByCSD(build.Cer, build.Key, build.Rfc, build.CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { uuid = "" } });
            Assert.Contains((string)resultExpect, response.messageDetail);
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
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
            Assert.True(!String.IsNullOrEmpty(response.data.acuse));
            Assert.True(response.data.folios.Count > 0);
        }
        /// <summary>
        /// Aceptacion o Rechazo por CSD
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task AcceptRejectByCSDAsync()
        {
            AcceptReject acceptReject = new AcceptReject(build.Url, build.User, build.Password);
            var response = await acceptReject.AcceptByCSD(build.CerReceptor, build.KeyReceptor, build.RfcReceptor, build.CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { uuid = "DB68450F-355B-4915-AFDC-A980497C4D70", action = EnumAcceptReject.Aceptacion } });
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
            Assert.True(!String.IsNullOrEmpty(response.data.acuse));
            Assert.True(response.data.folios.Count > 0);
        }
        /// <summary>
        /// Aceptacion o Rechazo por PFX
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task AcceptRejectByPfxAsync()
        {
            AcceptReject acceptReject = new AcceptReject(build.Url, build.User, build.Password);
            var response = await acceptReject.AcceptByPFX(build.PfxReceptor, build.RfcReceptor, build.CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { uuid = "DB68450F-355B-4915-AFDC-A980497C4D70", action = EnumAcceptReject.Aceptacion } });
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
            Assert.True(!String.IsNullOrEmpty(response.data.acuse));
            Assert.True(response.data.folios.Count > 0);
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
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
            Assert.True(!String.IsNullOrEmpty(response.data.acuse));
            Assert.True(response.data.folios.Count > 0);
        }
    }
}
