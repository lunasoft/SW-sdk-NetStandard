using Test_SW.Helpers;
using SW.Services.Status;
using Xunit;
using System.Net;
using System.Net.Security;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace Test_SW.Services.Status_Test
{
    public class Status_Test_45
    {
        private string urlSAT = "https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc";
        private string urlSATTest = "https://pruebacfdiconsultaqr.cloudapp.net/ConsultaCFDIService.svc";

        [Fact]
        public void StatusCFDI_Vigente()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT);
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831b", "zyvtsNVA==");
            Assert.True(response.Estado == "Vigente");
        }
        [Fact]
        public void StatusCFDI_NoEncontrado()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT,120);
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831", "zyvtsNVA==");
            Assert.Contains("602", response.CodigoEstatus);
        }
        [Fact]
        public void StatusCFDI_ExpresionNoValida()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT);
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "?", "021ea2fb-2254-4232-983b-9808c2ed831", "1234");
            Assert.Contains("601", response.CodigoEstatus);
        }
        [Fact]
        public void StatusCFDI_Cancelado()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT);
            var response = status.GetStatusCFDI("LSO1306189R5", "XAXX010101000", "0.50", "48face02-7352-4120-bcea-1563ab23968b", "zyvtsNVA==");
            Assert.True(response.Estado == "Cancelado");
        }

        [Fact(Skip = "Install SSL certificate")]
        public void StatusCFDI_Vigente_Test()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSATTest);
            var response = status.GetStatusCFDI("EKU9003173C9", "URE180429TM6", "180.00", "83d3e202-8c0d-41c9-bbae-ee908d22893e", "H9FfE4IA==");
            Assert.True(response.Estado == "Vigente");
        }
        [Fact(Skip = "Install SSL certificate")]
        public void StatusCFDI_NoEncontrado_Test()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSATTest,120);
            var response = status.GetStatusCFDI("EKU9003173C9", "URE180429TM6", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831", "H9FfE4IA==");
            Assert.Contains("602", response.CodigoEstatus);
        }
        [Fact(Skip = "Install SSL certificate")]
        public void StatusCFDI_ExpresionNoValida_Test()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSATTest);
            var response = status.GetStatusCFDI("EKU9003173C9", "URE180429TM6", "?", "021ea2fb-2254-4232-983b-9808c2ed831", "1234");
            Assert.Contains("601", response.CodigoEstatus);
        }
        [Fact(Skip = "Install SSL certificate")]
        public void StatusCFDI_Cancelado_Test()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSATTest);
            var response = status.GetStatusCFDI("EKU9003173C9", "URE180429TM6", "199.16", "73cfa94e-5d14-4ec0-af69-dfcf76cf4d71", "PlVGYGOA==");
            Assert.True(response.Estado == "Cancelado");
        }
    }
}
