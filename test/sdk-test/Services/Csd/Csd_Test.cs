using Test_SW.Helpers;
using SW.Services.Csd;
using Xunit;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Test_SW_sdk.Services.Csd
{
    public class Csd_Test
    {
        private readonly BuildSettings _build;
        public Csd_Test()
        {
            _build = new BuildSettings();
        }
        [Fact]
        public async Task Csd_Test_UploadCsdAsync_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.User, _build.Password);
            var response = await csd.UploadCsdAsync(_build.Cer, _build.Key, _build.CerPassword);
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
            Assert.True(string.IsNullOrEmpty(response.message));
        }
        [Fact]
        public async Task Csd_Test_Auth_UploadCsdAsync_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.UploadCsdAsync(_build.Cer, _build.Key, _build.CerPassword);
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
            Assert.True(string.IsNullOrEmpty(response.message));
        }
        [Fact]
        public async Task Csd_Test_UploadCsd_EmptyCsdAsync_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.User, _build.Password);
            var response = await csd.UploadCsdAsync("", _build.Key, _build.CerPassword);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("El certificado o llave privada vienen vacios"));
            Assert.Contains("at SW.Services.Csd.CsdService.UploadCsdServiceAsync", response.messageDetail);
        }
        [Fact]
        public async Task Csd_Test_UploadCsd_InvalidPassword_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.UploadCsdAsync(_build.Cer, _build.Key, "password");
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("Certificados"));
            Assert.True(response.messageDetail.Equals("El certificado no pertenece a la llave privada."));
            
        }
        [Fact]
        public async Task Csd_Test_GetAllCsd_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetAllCsdAsync();
            Assert.True(response.status.Equals("success"));
            Assert.NotNull(response.data);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
            Assert.True(string.IsNullOrEmpty(response.message));
            Assert.True(response.data.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.data.First().valid_to));
            Assert.True(!String.IsNullOrEmpty(response.data.First().valid_from));
            Assert.True(!String.IsNullOrEmpty(response.data.First().issuer_rfc));
            Assert.True(!String.IsNullOrEmpty(response.data.First().issuer_business_name));
            Assert.True(!String.IsNullOrEmpty(response.data.First().certificate_number));
            Assert.True(!String.IsNullOrEmpty(response.data.First().certificate_type));
            Assert.True(!String.IsNullOrEmpty(response.data.First().csd_certificate));
        }
        [Fact]
        public async Task Csd_Test_GetAllCsdByRfc_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetAllCsdAsync(_build.Rfc);
            Assert.True(response.status.Equals("success"));
            Assert.NotNull(response.data);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
            Assert.True(string.IsNullOrEmpty(response.message));
            Assert.True(response.data.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.data.First().valid_to));
            Assert.True(!String.IsNullOrEmpty(response.data.First().valid_from));
            Assert.True(!String.IsNullOrEmpty(response.data.First().issuer_rfc));
            Assert.True(!String.IsNullOrEmpty(response.data.First().issuer_business_name));
            Assert.True(!String.IsNullOrEmpty(response.data.First().certificate_number));
            Assert.True(!String.IsNullOrEmpty(response.data.First().certificate_type));
            Assert.True(!String.IsNullOrEmpty(response.data.First().csd_certificate));
        }
        [Fact]
        public async Task Csd_Test_GetAllCsdByRfc_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetAllCsdAsync("MYRFC");
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("Certificados"));
            Assert.True(response.messageDetail.Equals("El Rfc proporcionado es invalido. Favor de verificar."));
        }
        [Fact]
        public async Task Csd_Test_GetCsd_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetCsdAsync("30001000000400002434");
            Assert.True(response.status.Equals("success"));
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
            Assert.True(string.IsNullOrEmpty(response.message));
            Assert.NotNull(response.data);
            Assert.True(!String.IsNullOrEmpty(response.data.valid_to));
            Assert.True(!String.IsNullOrEmpty(response.data.valid_from));
            Assert.True(!String.IsNullOrEmpty(response.data.issuer_rfc));
            Assert.True(!String.IsNullOrEmpty(response.data.issuer_business_name));
            Assert.True(!String.IsNullOrEmpty(response.data.certificate_number));
            Assert.True(!String.IsNullOrEmpty(response.data.certificate_type));
            Assert.True(!String.IsNullOrEmpty(response.data.csd_certificate));
        }
        [Fact]
        public async Task Csd_Test_GetCsd_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetCsdAsync("MYNOCER");
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("Certificados"));
            Assert.True(response.messageDetail.Equals("Numero certificado invalido."));
        }
        [Fact]
        public async Task Csd_Test_DeleteCsdAsync_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.User, _build.Password);
            var response = await csd.DeleteCsdAsync("30001000000400002442");
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
            Assert.True(string.IsNullOrEmpty(response.message));
        }
        [Fact]
        public async Task Csd_Test_DeleteCsdAsync_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.DeleteCsdAsync("1234567890");
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("Certificados"));
            Assert.True(response.messageDetail.Equals("One or more errors occurred."));
        }
    }
}
