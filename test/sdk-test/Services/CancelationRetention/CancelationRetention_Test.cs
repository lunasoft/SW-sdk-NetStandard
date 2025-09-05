using System;
using SW.Services.CancelationRetention;
using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;
using Test_SW.Helper;

namespace Test_SW.Services.CancelationRetention_Test
{
    public class CancelationRetention_Test
    {
        //Cancelación de retenciones por XML
        [Fact]
        public async Task CancelationRetention_Auth_Test_CancelationUnoAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.User, build.Password);
            var response = await cancelationRetention.CancelarUnoAsync(build.CancelacionRetencionesXML);
            if (response.Status != "error")
            {
                Console.WriteLine(response.Data.Acuse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Acuse != null);
        }

        [Fact]
        public async Task CancelationRetention_Token_Test_CancelationUnoAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.Token);
            var response = await cancelationRetention.CancelarUnoAsync(build.CancelacionRetencionesXML);
            if (response.Status != "error")
            {
                Console.WriteLine(response.Data.Acuse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Acuse != null);
        }

        //Cancelación de retenciones por CSD
        [Fact]
        public async Task CancelationRetention_Auth_Test_CancelationUnoCsdAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.User, build.Password);
            string csdBase64 = build.Cer; 
            string keyBase64 = build.Key; 
            string password = build.CerPassword; 
            string rfc = build.Rfc; 
            string uuid = "1fae5735-ca51-4be4-9180-827c44fdb227";
            var response = await cancelationRetention.CancelarUnoCsdAsync(csdBase64,keyBase64,rfc,password,uuid,"02");
            if (response.Status != "error")
            {
                Console.WriteLine(response.Data.Acuse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Acuse != null);
        }

        [Fact]
        public async Task CancelationRetention_Token_Test_CancelationUnoCsdAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.Token);
            string csdBase64 = build.Cer;
            string keyBase64 = build.Key; 
            string password = build.CerPassword; 
            string rfc = build.Rfc; 
            string uuid = "1fae5735-ca51-4be4-9180-827c44fdb227";
            var response = await cancelationRetention.CancelarUnoCsdAsync(csdBase64, keyBase64, rfc, password, uuid, "02");
            if (response.Status != "error")
            {
                Console.WriteLine(response.Data.Acuse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Acuse != null);
        }

        [Fact]
        public async Task CancelationRetention_Token_Error_Test_CancelationUnoCsdAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.Token);
            string csdBase64 = build.Cer;
            string keyBase64 = build.Key;
            string password = build.CerPassword;
            string rfc = build.Rfc;
            string uuid = "1fae5735-ca51-4be4-9180-827c44fdb227";
            var resultExpect = "CR1310. Clave de motivo de cancelación no válida";
            var resultExpectMessage = "CACFDI33 - Problemas con el xml.";
            var response = await cancelationRetention.CancelarUnoCsdAsync(csdBase64, keyBase64, rfc, password, uuid, "0");
            CustomAssert.ErrorResponse(response);
            Assert.Contains((string)resultExpect, response.MessageDetail);
            Assert.Equal(response.Message, (string)resultExpectMessage);
        }

        //Cancelación de retenciones por PFX
        [Fact]
        public async Task CancelationRetention_Auth_Test_CancelationUnoPfxAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.User, build.Password);
            string pfxBase64 = build.Pfx; 
            string password = build.PfxPassword; 
            string rfc = build.Rfc; 
            string uuid = "1fae5735-ca51-4be4-9180-827c44fdb227";
            var response = await cancelationRetention.CancelarUnoPfxAsync(pfxBase64, rfc, password, uuid, "02");
            if (response.Status != "error")
            {
                Console.WriteLine(response.Data.Acuse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Acuse != null);
        }

        [Fact]
        public async Task CancelationRetention_Token_Test_CancelationUnoPfxAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.Token);
            string pfxBase64 = build.Pfx; 
            string password = build.PfxPassword; 
            string rfc = build.Rfc; 
            string uuid = "1fae5735-ca51-4be4-9180-827c44fdb227";
            var response = await cancelationRetention.CancelarUnoPfxAsync(pfxBase64, rfc, password, uuid, "02");
            if (response.Status != "error")
            {
                Console.WriteLine(response.Data.Acuse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Acuse != null);
        }

        [Fact]
        public async Task CancelationRetention_Token_Error_Test_CancelationUnoPfxAsync()
        {
            var build = new BuildSettings();
            CancelationRetention cancelationRetention = new CancelationRetention(build.Url, build.Token);
            string pfxBase64 = build.Pfx;
            string password = build.PfxPassword;
            string rfc = build.Rfc;
            string uuid = "1fae5735-ca51-4be4-9180-827c44fdb227";
            var resultExpect = "El archivo PFX es requerido.";
            var resultExpectMessage = "CACFDI33 - Problemas con los campos.";
            var response = await cancelationRetention.CancelarUnoPfxAsync("", rfc, password, uuid, "02");
            CustomAssert.ErrorResponse(response);
            Assert.Contains((string)resultExpect, response.MessageDetail);
            Assert.Equal(response.Message, (string)resultExpectMessage);
        }
    }
}
