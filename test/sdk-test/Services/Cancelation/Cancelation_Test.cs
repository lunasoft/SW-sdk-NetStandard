using System;
using System.Threading.Tasks;
using SW.Services.Cancelation;
using Test_SW.Helpers;
using Xunit;

namespace Test_SW.Services.Cancelation_Test
{
    public class Cancelation_Test
    {
        private const string uuid = "478569b5-c323-4dc4-91cf-b6e9f6979527";
        [Fact(Skip = "Change of RFC for testing")]
        public async Task Cancelation_Test_CancelationByCSDAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            //Al igual que el objeto de stamp, se indica url del ambiente al cual apuntara y credenciales de acceso o token.
            string csdBase64 = build.Cer;//.Cer en Base64
            string keyBase64 = build.Key;//.Key en Base64
            string password = build.CerPassword;//password del CSD
            string rfc = build.Rfc;
            string folioSustitucion = Guid.NewGuid().ToString();
            var response = await cancelation.CancelarByCSDAsync(csdBase64, keyBase64, rfc, password, uuid, "01", folioSustitucion);
            if (response.Status != "error")
            {
                //acuse de cancelación
                Console.WriteLine(response.data.acuse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            Assert.True(response.data.acuse != null && response.Status == "success");
        }
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task Cancelation_Test_CancelationByRfcUuidAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByRfcUuidAsync(build.Rfc, uuid, "02");
            Assert.True(response.data.acuse != null && response.Status == "success");
        }

        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task Cancelation_Test_CancelationByPFXAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByPFXAsync(build.Pfx, build.Rfc, build.PfxPassword, uuid, "02");
            Assert.True(response != null && response.Status == "success");
        }

        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task Cancelation_Test_CancelationByXMLAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByXMLAsync(build.CancelacionXML);
            Assert.True(response != null && response.Status == "success");
        }
        [Fact(Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task Cancelation_Test_ValidateParametersAsync()
        {
            var resultExpect = "Son necesarios el .Cer y el .Key en formato B64";
            var resultExpectStatus = "error";
            var resultExpectMessage = "CACFDI33 - Problemas con los campos.";
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByCSDAsync(build.Cer, build.Key, build.Rfc, build.CerPassword, uuid, "02");
            Assert.NotNull(response);
            Assert.Contains((string)resultExpect, response.MessageDetail);
            Assert.Equal(response.Status, (string)resultExpectStatus);
            Assert.Equal(response.Status, (string)resultExpectMessage);
        }
    }
}