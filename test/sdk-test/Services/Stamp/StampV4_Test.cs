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
    public class StampV4_Test
    {
        [Fact]
        public async Task Stamp_Test_StampV4XMLV1Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }

        [Fact]
        public async Task Stamp_Test_StampV4XMLV2Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV2WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);
        }

        [Fact]
        public async Task Stamp_Test_StampV4XMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV3WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");

            response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.Status == "error"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);

        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV4WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);

        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url + "/ot", build.Token);
            var xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Equal("404", response.Message);
            Assert.Equal("Not Found", response.MessageDetail);
        }
        [Fact]
        public async Task Stamp_Test_ValidateFormatTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token + ".");
            var xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateExistTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, "");
            var xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateEmptyXMLAsync()
        {
            var resultExpect = "Xml CFDI33 no proporcionado o viene vacio.";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var response = await stamp.TimbrarV1Async(string.Empty, "someemail@some.com");
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Equal(response.Message, (string)resultExpect);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateSpecialCharactersFromXMLAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_specialchar.xml");
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.NotNull(response);
            Assert.True(response.Status == "success", "Result not expected. Error: " + response.Message);
            Assert.False(string.IsNullOrEmpty(response.Data.Tfd), "Result not expected. Error: " + response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateIsUTF8FromXMLAsync()
        {
            var resultExpect = "301";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/cfdi40_ansi.xml"));
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.True(response.Message.Contains(resultExpect), "Result not expected. Error: " + response.Message);
            Assert.Contains("Error al leer el documento XML. La estructura del documento no es un Xml valido", response.MessageDetail);
        }
        [Fact]
        public async Task Stamp_Test_MultipleStampV4XMLV1byTokenAsync()
        {
            var build = new BuildSettings();
            var resultExpect = false;
            int iterations = 10;
            StampV4 stamp = new StampV4(build.Url, build.Token);
            List<StampResponseV1> listXmlResult = new List<StampResponseV1>();
            for (int i = 0; i < iterations; i++)
            {
                string xml = GetXml(build);
                xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
                listXmlResult.Add(response);
            }
            if (listXmlResult != null)
                resultExpect = listXmlResult.FindAll(w => w.Status == "success" || w.Message.Contains("72 horas")).Count == iterations;

            Assert.True((bool)resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV1_HashedCustomId_IdDuplicado_Error()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var customId = Guid.NewGuid().ToString();
            customId = string.Concat(Enumerable.Repeat(customId, 4));
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, null, customId);
            Assert.True(response.Status == "success");
            Assert.True(!String.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            xml = GetXml(build);
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml, null, customId);
            Assert.True(response.Status == "error");
            Assert.True(response.Message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.");
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV1_InvalidCustomId_Error()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var customId = Guid.NewGuid().ToString();
            customId = string.Concat(Enumerable.Repeat(customId, 10));
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, null, customId);
            Assert.NotNull(response);
            Assert.True(response.Status == "error");
            Assert.True(response.Message == "El CustomId no es válido o viene vacío.");
            Assert.Contains("at SW.Helpers.Validation.ValidateCustomId(String customId)", response.MessageDetail);
        }
        private string GetXml(BuildSettings build, string fileName = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/CFDI40/{0}", fileName ?? "cfdi40.xml")));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
