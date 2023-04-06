﻿using System;
using System.Text;
using Test_SW.Helpers;
using SW.Services.Stamp;
using System.IO;
using Xunit;
using System.Threading.Tasks;

namespace Test_SW
{
    /// <summary>
    /// Summary description for UT_Service_Validation
    /// </summary>
    public class UT_Service_Validation
    {
        BuildSettings Build = new BuildSettings();
        [Fact]
        public async Task UT_Service_Validation_ErrorExceptionAsync()
        {
            Stamp stamp = new Stamp("http://fake123999459493494949.com", Build.User, Build.Password);
            string xml = GetXml();
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.True(response.status == "error");
        }
        [Fact]
        public async Task UT_Service_Validation_401Async()
        {
            Stamp stamp = new Stamp(Build.Url, Build.Token + "FakeToken");
            string xml = GetXml();
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.Contains("Firma inválidad. Se esperaba", response.message);
        }

        [Fact]
        public async Task UT_Service_Validation_404Async()
        {
            Stamp stamp = new Stamp(Build.Url + "/fakeurl", Build.User, Build.Password);
            string xml = GetXml();
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.Contains("404", response.message);
        }

        [Fact]
        public async Task UT_Service_Validation_STAMPV4_BIG_XMLAsync()
        {
            Stamp stamp = new Stamp(Build.Url, Build.User, Build.Password);
            string xml = GetXml(Build, true, "cfdi40_big.xml");
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            if (response.status == "error")
                Assert.True(response.message.Contains("72 horas"), "Error en el servicio: " + response.message + " " + response.messageDetail);
            else
            {
                Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
            }
        }
        [Fact]
        public async Task UT_Service_Validation_STAMPV4_BIG_XML_2Async()
        {
            Stamp stamp = new Stamp(Build.Url, Build.User, Build.Password);
            string xml = GetXml(Build, true, "cfdi40_big.xml");
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            if (response.status == "error")
                Assert.True(response.message.Contains("72 horas"), "Error en el servicio: " + response.message + " " + response.messageDetail);
            else
            {
                Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
            }
        }
        private string GetXml(BuildSettings build = null, bool sign = false, string filename = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/CFDI40/{0}", filename ?? "cfdi40.xml")));
            return sign ? SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword) : xml;
        }
    }
}
