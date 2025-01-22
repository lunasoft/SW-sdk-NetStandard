using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SW.Services.Stamp;
using Test_SW.Helpers;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using Test_SW.Helper;

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
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV2Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV2WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV3WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");

            response = (StampResponseV3)await stamp.TimbrarV3Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV4XMLV4WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            response = (StampResponseV4)await stamp.TimbrarV4Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);
        }
        [Fact(Skip ="Se omite prueba para no afectar el resto de UT, activar segun se requiera")]
        public async Task Stamp_Test_TimbrarV1TooLongAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build, "70000conceptos.xml");
            var response = (StampResponseV1)await stamp.TimbrarV1TooLongAsync(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url + "/ot", build.Token);
            var xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml, "someemail@some.com");
            CustomAssert.ErrorResponse(response);
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
            CustomAssert.ErrorResponse(response);
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
            CustomAssert.ErrorResponse(response);
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
            CustomAssert.ErrorResponse(response);
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
            CustomAssert.SuccessResponse(response, response.Data);
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
            CustomAssert.ErrorResponse(response);
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
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!String.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            xml = GetXml(build);
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml, null, customId);
            CustomAssert.ErrorResponse(response);
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
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "El CustomId no es válido o viene vacío.");
            Assert.Contains("at SW.Helpers.Validation.ValidateCustomId(String customId)", response.MessageDetail);
        }
        [Fact]
        public async Task Stamp_Test_TimbrarV1TooLongAsync_Error()
        {
            var resultExpect = "En este path sólo es posible timbrar facturas que tengan entre 10000 y 120000 nodos cfdi:Concepto  por este path";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build, "150000conceptos.xml");
            var response = (StampResponseV1)await stamp.TimbrarV1TooLongAsync(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Message), resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_TimbrarV1TooLongAsync_ErrorPath()
        {
            var resultExpect = "En este path sólo es posible timbrar facturas que tengan más de 10000 nodos" +
                "cfdi:Concepto , favor de utiliza el timbrado normal";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1TooLongAsync(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Message), resultExpect);
        }
        //Email
        [Fact]
        public async Task Stamp_Test_TimbrarV1Email_Succes()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_TimbrarV1MultiEmail_Succes()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail1@some.com,someemail2@some.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_TimbrarV1MultiEmail_Error()
        {
            var resultExpect = "El formato de uno o más correos no es correcto.";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com,someemailsome.co");
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Message), resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_TimbrarV1MaxEmail_Error()
        {
            var resultExpect = "El listado de correos contiene más de 5 correos o está vacío.";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            string emails = "someemail1@some.com,someemail2@some.com,someemail3@some.com,someemail4@some.com,someemail5@some.com,someemail6@some.com";
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, emails);
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Message), resultExpect);
        }

        private string GetXml(BuildSettings build, string fileName = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/CFDI40/{0}", fileName ?? "cfdi40.xml")));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
