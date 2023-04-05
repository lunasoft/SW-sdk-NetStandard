using System;
using System.Text;
using Test_SW.Helpers;
using SW.Services.Stamp;
using System.IO;
using System.Xml;
using Xunit;
using System.Threading.Tasks;

namespace Test_SW.Services.Issue
{
    public class IssueV2_Test
    {
        [Fact]
        public async Task Issue_Test_IssueV2XMLV1Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV2 issue = new SW.Services.Issue.IssueV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await issue.TimbrarV1Async(xml);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
            response = (StampResponseV1)await issue.TimbrarV1Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }

        [Fact]
        public async Task Issue_Test_IssueV2XMLV2Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV2 issue = new SW.Services.Issue.IssueV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
            response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }

        [Fact]
        public async Task Issue_Test_IssueV2XMLV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV2 issue = new SW.Services.Issue.IssueV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV3)await issue.TimbrarV3Async(xml);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV3)await issue.TimbrarV3Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }

        [Fact]
        public async Task Issue_Test_StampXMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV2 issue = new SW.Services.Issue.IssueV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml);
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
            response = (StampResponseV4)await issue.TimbrarV4Async(xml);
            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }

        [Fact]
        public async Task Issue_Test_StampV4XMLbyTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml);
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
        }

        [Fact]
        public async Task Issue_Test_StampV4XMLbyUserAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml);
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
        }

        [Fact]
        public async Task Issue_Test_StampV4XMLEmailAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml, "email@domain.com");
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
        }

        [Fact]
        public async Task Issue_Test_StampV4XMLPDFAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml, extras: new string []{"pdf"});
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
        }

        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/cfdi40.xml"));
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
