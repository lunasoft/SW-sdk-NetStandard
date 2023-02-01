using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SW.Helpers;
using SW.Services.Stamp;
using Test_SW.Helpers;
using Xunit;
using System.Threading.Tasks;

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
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        
        [Fact]
        public async Task Stamp_Test_StampV2XMLV2Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV2WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.data.cfdi);
        }

        [Fact]
        public async Task Stamp_Test_StampV2XMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV3WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");

            response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.status == "error"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.Contains("cfdi:Addenda", response.data.cfdi);

        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV4WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.data.cfdi);

        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url + "/ot", build.Token);
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("404", response.message);
            Assert.Equal("error", response.status);
            Assert.Equal("Not Found", response.messageDetail);
        }
        [Fact]
        public async Task Stamp_Test_ValidateFormatTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token + ".");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.status);
            Assert.Contains("El token debe contener 3 partes", response.message);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateExistTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, "");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.status);
            Assert.Contains("El token debe contener 3 partes", response.message);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateEmptyXMLAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/EmptyXML.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.status);
            Assert.Equal("Xml CFDI33 no proporcionado o viene vacio.", response.message);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateSpecialCharactersFromXMLAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/SpecialCharacters.xml");
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            var response = await stamp.TimbrarV1Async(xml);
            Assert.True(response.status == "success", "Result not expected. Error: " + response.message);
            Assert.False(string.IsNullOrEmpty(response.data.tfd), "Result not expected. Error: " + response.message);
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
            Assert.Equal("error", response.status);
            Assert.True(response.message.Contains(resultExpect), "Result not expected. Error: " + response.message);
            Assert.Contains("Error al leer el documento XML. La estructura del documento no es un Xml valido", response.messageDetail);
        }
        [Fact]
        public async Task Stamp_Test_MultipleStampV2XMLV1byTokenAsync()
        {
            var build = new BuildSettings();
            var resultExpect = false;
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
            if (listXmlResult != null)
                resultExpect = listXmlResult.FindAll(w => w.status == ResponseType.success.ToString() || w.message.Contains("72 horas")).Count == iterations;

            Assert.True((bool)resultExpect);
        }
        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
