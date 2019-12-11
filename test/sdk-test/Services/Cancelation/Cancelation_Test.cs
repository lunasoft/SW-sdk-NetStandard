using System;
using System.Threading.Tasks;
using SW.Services.Cancelation;
using Test_SW.Helpers;
using Xunit;

namespace Test_SW.Services.Cancelation_Test
{
    public class Cancelation_Test
    {
        private const string uuid = "c2c57c10-45a2-4f1c-8f7b-c660a107ffa2";
        [Fact(Skip = "Change of RFC for testing")]
        public async Task Cancelation_Test_CancelationByCSDAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "demo", "123456789");
            //Al igual que el objeto de stamp, se indica url del ambiente al cual apuntara y credenciales de acceso o token.
            string csdBase64 = build.Cer;//.Cer en Base64
            string keyBase64 = build.Key;//.Key en Base64
            string password = build.CerPassword;//password del CSD
            string rfc = "LAN8507268IA";
            string uuid = "7028573d-5a18-4331-8285-cd97b156c901";
            var response = await cancelation.CancelarByCSDAsync(csdBase64, keyBase64, rfc, password, uuid);
            if (response.status != "error")
            {
                //acuse de cancelación
                Console.WriteLine(response.data.acuse);
            }
            else
            {
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            Assert.True(response.data.acuse != null && response.status == "success");
        }
        [Fact(Skip = "Change of RFC for testing")]
        public async Task Cancelation_Test_CancelationByRfcUuidAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByRfcUuidAsync(build.Rfc, uuid);
            Assert.True(response.data.acuse != null && response.status == "success");
        }

        [Fact(Skip = "Change of RFC for testing")]
        public async Task Cancelation_Test_CancelationByPFXAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByPFXAsync(build.Pfx, build.Rfc, build.CerPassword, uuid);
            Assert.True(response != null && response.status == "success");
        }
        
        [Fact(Skip = "Change of RFC for testing")]
        public async Task Cancelation_Test_CancelationByXMLAsync()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByXMLAsync(build.Acuse);
            Assert.True(response != null && response.status == "success");
        }
        [Fact(Skip = "Change of RFC for testing")]
        public async Task Cancelation_Test_ValidateParametersAsync()
        {
            var resultExpect = "Son necesarios el .Cer y el .Key en formato B64";
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = await cancelation.CancelarByCSDAsync(build.Cer, build.Key, build.Rfc, build.CerPassword, "");
            Assert.Contains((string)resultExpect, response.messageDetail);
        }
    }
}