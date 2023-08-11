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
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.tfd viene vacio.");
            response = (StampResponseV1)await issue.TimbrarV1Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Issue_Test_IssueV2XMLV2Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV2 issue = new SW.Services.Issue.IssueV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.tfd viene vacio.");
            response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Issue_Test_IssueV2XMLV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV2 issue = new SW.Services.Issue.IssueV2(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV3)await issue.TimbrarV3Async(xml);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.tfd viene vacio.");
            response = (StampResponseV3)await issue.TimbrarV3Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Issue_Test_StampXMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV2 issue = new SW.Services.Issue.IssueV2(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml);
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
            response = (StampResponseV4)await issue.TimbrarV4Async(xml);
            Assert.True(response.Status == "error" && response.Message == "307. El comprobante contiene un timbre previo.");
        }
        [Fact]
        public async Task Issue_Test_StampV4XMLbyTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml);
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
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
        [Fact]
        public async Task Issue_Test_StampV4XMLbyUserAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml);
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
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
        [Fact]
        public async Task Issue_Test_StampV4XMLEmailAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml, "email@domain.com");
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
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
        [Fact]
        public async Task Issue_Test_StampV4XMLPDFAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV4)await issue.TimbrarV4Async(xml, extras: new string[] { "pdf" });
            Assert.True(response.Data != null, "El resultado Data viene vacio.");
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
