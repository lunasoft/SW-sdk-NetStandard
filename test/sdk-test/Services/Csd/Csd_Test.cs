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
            Assert.True(response.Status == "success");
            Assert.NotNull(response.Data);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
            Assert.True(string.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task Csd_Test_Auth_UploadCsdAsync_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.UploadCsdAsync(_build.Cer, _build.Key, _build.CerPassword);
            Assert.True(response.Status == "success");
            Assert.NotNull(response.Data);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
            Assert.True(string.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task Csd_Test_UploadCsd_EmptyCsdAsync_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.User, _build.Password);
            var response = await csd.UploadCsdAsync("", _build.Key, _build.CerPassword);
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("El certificado o llave privada vienen vacios"));
            Assert.Contains("at SW.Services.Csd.CsdService.UploadCsdServiceAsync", response.MessageDetail);
        }
        [Fact]
        public async Task Csd_Test_UploadCsd_InvalidPassword_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.UploadCsdAsync(_build.Cer, _build.Key, "password");
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("Certificados"));
            Assert.True(response.MessageDetail.Equals("El certificado no pertenece a la llave privada."));

        }
        [Fact]
        public async Task Csd_Test_GetAllCsd_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetAllCsdAsync();
            Assert.True(response.Status.Equals("success"));
            Assert.NotNull(response.Data);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
            Assert.True(string.IsNullOrEmpty(response.Message));
            Assert.True(response.Data.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.First().ValidTo));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().ValidFrom));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().IssuerRfc));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().IssuerBusinessName));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().CertificateNumber));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().CertificateType));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().CsdCertificate));
        }
        [Fact]
        public async Task Csd_Test_GetAllCsdByRfc_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetAllCsdAsync(_build.Rfc);
            Assert.True(response.Status.Equals("success"));
            Assert.NotNull(response.Data);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
            Assert.True(string.IsNullOrEmpty(response.Message));
            Assert.True(response.Data.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.First().ValidTo));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().ValidFrom));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().IssuerRfc));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().IssuerBusinessName));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().CertificateNumber));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().CertificateType));
            Assert.True(!String.IsNullOrEmpty(response.Data.First().CsdCertificate));
        }
        [Fact]
        public async Task Csd_Test_GetAllCsdByRfc_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetAllCsdAsync("MYRFC");
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("Certificados"));
            Assert.True(response.MessageDetail.Equals("El Rfc proporcionado es invalido. Favor de verificar."));
        }
        [Fact]
        public async Task Csd_Test_GetCsd_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetCsdAsync("30001000000400002434");
            Assert.True(response.Status.Equals("success"));
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
            Assert.True(string.IsNullOrEmpty(response.Message));
            Assert.NotNull(response.Data);
            Assert.True(!String.IsNullOrEmpty(response.Data.ValidTo));
            Assert.True(!String.IsNullOrEmpty(response.Data.ValidFrom));
            Assert.True(!String.IsNullOrEmpty(response.Data.IssuerRfc));
            Assert.True(!String.IsNullOrEmpty(response.Data.IssuerBusinessName));
            Assert.True(!String.IsNullOrEmpty(response.Data.CertificateNumber));
            Assert.True(!String.IsNullOrEmpty(response.Data.CertificateType));
            Assert.True(!String.IsNullOrEmpty(response.Data.CsdCertificate));
        }
        [Fact]
        public async Task Csd_Test_GetCsd_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.GetCsdAsync("MYNOCER");
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("Certificados"));
            Assert.True(response.MessageDetail.Equals("Numero certificado invalido."));
        }
        [Fact]
        public async Task Csd_Test_DeleteCsdAsync_Success()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.User, _build.Password);
            var response = await csd.DeleteCsdAsync("30001000000400002442");
            Assert.True(response.Status == "success");
            Assert.NotNull(response.Data);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
            Assert.True(string.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task Csd_Test_DeleteCsdAsync_Error()
        {
            CsdUtils csd = new CsdUtils(_build.Url, _build.Token);
            var response = await csd.DeleteCsdAsync("1234567890");
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("Certificados"));
            Assert.True(response.MessageDetail.Equals("One or more errors occurred."));
        }
    }
}
