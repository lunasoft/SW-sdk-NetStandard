using System;
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
            Assert.True(response.Status == "error");
        }
        [Fact]
        public async Task UT_Service_Validation_401Async()
        {
            Stamp stamp = new Stamp(Build.Url, Build.Token + "FakeToken");
            string xml = GetXml();
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.Contains("Firma inválidad. Se esperaba", response.Message);
        }
        [Fact]
        public async Task UT_Service_Validation_404Async()
        {
            Stamp stamp = new Stamp(Build.Url + "/fakeurl", Build.User, Build.Password);
            string xml = GetXml();
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.Contains("404", response.Message);
        }
        [Fact]
        public async Task UT_Service_Validation_STAMPV4_BIG_XMLAsync()
        {
            Stamp stamp = new Stamp(Build.Url, Build.User, Build.Password);
            string xml = GetXml(Build, true, "cfdi40_big.xml");
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            if (response.Status == "error")
                Assert.True(response.Message.Contains("72 horas"), "Error en el servicio: " + response.Message + " " + response.MessageDetail);
            else
            {
                Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
            }
        }
        [Fact]
        public async Task UT_Service_Validation_STAMPV4_BIG_XML_2Async()
        {
            Stamp stamp = new Stamp(Build.Url, Build.User, Build.Password);
            string xml = GetXml(Build, true, "cfdi40_big.xml");
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            if (response.Status == "error")
                Assert.True(response.Message.Contains("72 horas"), "Error en el servicio: " + response.Message + " " + response.MessageDetail);
            else
            {
                Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
                Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
            }
        }
        private string GetXml(BuildSettings build = null, bool sign = false, string filename = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/CFDI40/{0}", filename ?? "cfdi40.xml")));
            return sign ? SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword) : xml;
        }
    }
}
