using System;
using System.Text;
using Test_SW.Helpers;
using SW.Services.Stamp;
using System.IO;
using System.Xml;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

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
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
        }

        [Fact]
        public async Task Issue_Test_IssueXMLV2Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
        }

        [Fact]
        public async Task Issue_Test_IssueXMLV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV3)await issue.TimbrarV3Async(xml);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
        }

        [Fact]
        public async Task Issue_Test_StampXMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.Token);
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
        public async Task Issue_Test_IssueV4XMLV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueV4 issue = new SW.Services.Issue.IssueV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV3)await issue.TimbrarV3Async(xml, "email@domainxyz.abc.com");
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
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
            Assert.True(response.status == "success");
            Assert.True(!String.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
            xml = GetXml(build);
            response = await issue.TimbrarV1Async(xml, null, customId);
            Assert.True(response.status == "error");
            Assert.True(response.message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.");
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
            Assert.True(response.status == "error");
            Assert.True(response.message == "El CustomId no es válido o viene vacío.");
        }
        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/fileIssue.xml"));
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
