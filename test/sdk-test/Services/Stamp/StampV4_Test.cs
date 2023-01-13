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
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        
        [Fact]
        public async Task Stamp_Test_StampV4XMLV2Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV2WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.data.cfdi);
        }

        [Fact]
        public async Task Stamp_Test_StampV4XMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV3WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");

            response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            Assert.True(response.status == "error"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.Contains("cfdi:Addenda", response.data.cfdi);

        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV4WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.data.cfdi);

        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var resultExpect = "404";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url + "/ot", build.Token);
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.Equal(response.message, (string)resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_ValidateFormatTokenAsync()
        {
            var resultExpect = "Token Mal Formado";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token + ".");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.True(response.message.Contains("401"), (string)resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_ValidateExistTokenAsync()
        {
            var resultExpect = "401 Unauthorized";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, "");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.True(response.message.Contains("401"), (string)resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_ValidateEmptyXMLAsync()
        {
            var resultExpect = "Xml CFDI33 no proporcionado o viene vacio.";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/EmptyXML.xml");
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.Equal(response.message, (string)resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_ValidateSpecialCharactersFromXMLAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/SpecialCharacters.xml");
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.True(response.status == "success", "Result not expected. Error: " + response.message);
            Assert.False(string.IsNullOrEmpty(response.data.tfd), "Result not expected. Error: " + response.message);
        }
        [Fact]
        public async Task Stamp_Test_ValidateIsUTF8FromXMLAsync()
        {
            var resultExpect = "301";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/fileANSI.xml"));            
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            Assert.True(response.message.Contains(resultExpect), "Result not expected. Error: " + response.message);
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
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
                xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
                listXmlResult.Add(response);
            }
            if (listXmlResult != null)
                resultExpect = listXmlResult.FindAll(w => w.status == ResponseType.success.ToString() || w.message.Contains("72 horas")).Count == iterations;

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
            Assert.True(response.status == "success");
            Assert.True(!String.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
            xml = GetXml(build);
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml, null, customId);
            Assert.True(response.status == "error"); 
            Assert.True(response.message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.");
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
            Assert.True(response.status == "error");
            Assert.True(response.message == "El CustomId no es válido o viene vacío.");
        }
        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
