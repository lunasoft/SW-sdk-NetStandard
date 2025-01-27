﻿using System;
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
    public class StampV2_Test
    {
        [Fact]
        public async Task Stamp_Test_StampV2XMLV1Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV2Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV2WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.User, build.Password);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV3WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");

            response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
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
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Stamp_Test_StampV2XMLV4WithAddenda307Async()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_addenda.xml");
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
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
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
            Assert.Contains("cfdi:Addenda", response.Data.Cfdi);
        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url + "/ot", build.Token);
            string xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.Equal("404", response.Message);
            Assert.Equal("Not Found", response.MessageDetail);
        }
        [Fact]
        public async Task Stamp_Test_ValidateFormatTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token + ".");
            string xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateExistTokenAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, "");
            string xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml);
            CustomAssert.ErrorResponse(response);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateEmptyXMLAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var response = await stamp.TimbrarV1Async(String.Empty);
            CustomAssert.ErrorResponse(response);
            Assert.Equal("Xml CFDI33 no proporcionado o viene vacio.", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateSpecialCharactersFromXMLAsync()
        {
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_specialchar.xml");
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            var response = await stamp.TimbrarV1Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.False(string.IsNullOrEmpty(response.Data.Tfd), "Result not expected. Error: " + response.Message);
        }
        [Fact]
        public async Task Stamp_Test_ValidateIsUTF8FromXMLAsync()
        {
            var resultExpect = "301";
            var build = new BuildSettings();
            StampV2 stamp = new StampV2(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/CFDI40/cfdi40_ansi.xml");
            var response = await stamp.TimbrarV1Async(xml);
            CustomAssert.ErrorResponse(response);
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
                string xml = GetXml(build);
                xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
                listXmlResult.Add(response);
            }
            Assert.True(listXmlResult.Count.Equals(iterations));
            Assert.True(!listXmlResult.Any(l => l.Status != "success"));
        }
        private string GetXml(BuildSettings build, string filename = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/CFDI40/{0}", filename ?? "cfdi40.xml")));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
