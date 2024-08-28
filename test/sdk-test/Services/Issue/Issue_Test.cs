using System;
using System.Text;
using Test_SW.Helpers;
using SW.Services.Stamp;
using System.IO;
using System.Xml;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using Test_SW.Helper;

namespace Test_SW.Services.Issue
{
    public class Issue_Test
    {
        [Fact]
        public async Task Issue_Test_IssueXMLV1Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await issue.TimbrarV1Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Issue_Test_IssueXMLV2Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Issue_Test_IssueXMLV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV3)await issue.TimbrarV3Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Issue_Test_StampXMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.qrCode viene vacio.");
        }
        [Fact]
        public async Task Issue_Test_IssueV4XMLV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV3)await issue.TimbrarV3Async(xml, "email@domainxyz.abc.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
        }
        [Fact(Skip = "Error en el servicio")]
        public async Task Issue_Test_TimbrarV1TooLongAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build, "70000conceptos.xml");
            var response = (StampResponseV1)await issue.TimbrarV1TooLongAsync(xml);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task IssueV4XMLV1_HashedCustomId_IdDuplicado_Error()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var customId = Guid.NewGuid().ToString();
            customId = string.Concat(Enumerable.Repeat(customId, 4));
            var xml = GetXml(build);
            var response = await issue.TimbrarV1Async(xml, null, customId);
            Assert.True(response.Status == "success");
            Assert.True(!String.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            xml = GetXml(build);
            response = await issue.TimbrarV1Async(xml, null, customId);
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.");
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task IssueV4XMLV1_InvalidCustomId_Error()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var customId = Guid.NewGuid().ToString();
            customId = string.Concat(Enumerable.Repeat(customId, 10));
            var xml = GetXml(build);
            var response = await issue.TimbrarV1Async(xml, null, customId);
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "El CustomId no es válido o viene vacío.");
            Assert.Contains("at SW.Helpers.Validation.ValidateCustomId", response.MessageDetail);
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
        public async Task Issue_Test_TimbrarV1TooLongAsync_ErrorPath()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await issue.TimbrarV1TooLongAsync(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Message), "En este path sólo es posible timbrar facturas que tengan más de 10000 nodos" +
                "cfdi:Concepto , favor de utiliza el timbrado normal");
        }
        private string GetXml(BuildSettings build, string fileName = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(string.Format("Resources/CFDI40/{0}", fileName ?? "cfdi40.xml")));
            xml = Helpers.SignTools.RemoverCaracteresInvalidosXml(xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("Fecha", DateTime.Now.AddHours(-12).ToString("s"));
            doc.DocumentElement.SetAttribute("Folio", Guid.NewGuid().ToString());
            xml = doc.OuterXml;
            return xml;
        }
    }
}
