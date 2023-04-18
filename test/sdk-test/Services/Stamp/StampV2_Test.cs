using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SW.Helpers;
using SW.Services.Stamp;
using Test_SW.Helpers;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

namespace Test_SW.Services.Stamp_Test
{
    public class StampV2_Test
    {
        [Fact]
        public async Task Stamp_Test_StampV2XMLV1Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }

        [Fact]
        public async Task Stamp_Test_StampV2XMLV2Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV2WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("Cfdi:Addenda", response.Data.Cfdi);
        }

        [Fact]
        public async Task Stamp_Test_StampV2XMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV3WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");

            response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.Status == "error"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.Contains("Cfdi:Addenda", response.Data.Cfdi);

        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.selloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV4WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.selloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("Cfdi:Addenda", response.Data.Cfdi);

        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url + "/ot", build.Token);
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("404", response.Message);
            Assert.Equal("error", response.Status);
            Assert.Equal("Not Found", response.MessageDetail);
        }
        [Fact]
        public async Task Stamp_Test_ValidateFormatTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token + ".");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateExistTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, "");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateEmptyXMLAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/EmptyXML.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Equal("Xml Cfdi33 no proporcionado o viene vacio.", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateSpecialCharactersFromXMLAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/SpecialCharacters.xml");
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            var response = await stamp.TimbrarV1Async(xml);
            Assert.True(response.Status == "success", "Result not expected. Error: " + response.Message);
            Assert.False(string.IsNullOrEmpty(response.Data.Tfd), "Result not expected. Error: " + response.Message);
        }
        [Fact]
        public async Task Stamp_Test_ValidateIsUTF8FromXMLAsync()
        {
            var resultExpect = "301";
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/fileANSI.xml"));
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.True(response.Message.Contains(resultExpect), "Result not expected. Error: " + response.Message);
            Assert.Contains("Error al leer el documento XML. La estructura del documento no es un Xml valido", response.MessageDetail);
        }
        [Fact]
        public async Task Stamp_Test_MultipleStampV2XMLV1byTokenAsync()
        {
            var build = new BuildSettings();
            int iterations = 10;
            StampV2 stamp = new StampV2(build.Url, build.Token);
            List<StampResponseV1> listXmlResult = new List<StampResponseV1>();
            for (int i = 0; i < iterations; i++)
            {
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
                xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
                listXmlResult.Add(response);
            }
            Assert.True(listXmlResult.Count.Equals(iterations));
            Assert.True(!listXmlResult.Any(l => l.Status != "success"));
        }
        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
