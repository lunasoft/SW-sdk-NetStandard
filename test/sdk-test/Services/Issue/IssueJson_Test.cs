using System;
using System.Text;
using Test_SW.Helpers;
using SW.Services.Stamp;
using System.IO;
using Newtonsoft.Json.Linq;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using SW.Services.Issue;

namespace Test_SW.Services.Issue
{
    public class IssueJson_Test
    {
        [Fact]
        public async Task IssueJsonV1Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJson issue = new SW.Services.Issue.IssueJson(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV1)await issue.TimbrarJsonV1Async(json);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
        }

        [Fact]
        public async Task IssueJsonV2Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJson issue = new SW.Services.Issue.IssueJson(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV2)await issue.TimbrarJsonV2Async(json);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
        }

        [Fact]
        public async Task IssueJsonV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJson issue = new SW.Services.Issue.IssueJson(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV3)await issue.TimbrarJsonV3Async(json);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
        [Fact]
        public async Task IssueV4JsonV4fAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "someemail@some.com");
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
        }
        [Fact]
        public async Task IssueV4JsonV4CustomIdfAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var customNumber = new Random().Next(1000,10000).ToString();
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "someemail@some.com", customNumber);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
            response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "someemail@some.com", customNumber);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
        }
        [Fact]
        public async Task IssueV4JsonV4MultipleEmailAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var customNumber = new Random().Next(1000,10000).ToString();
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "email1@abcdfg.com,email2@abcdfg.com", customNumber);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
        }
        [Fact]
        public async Task IssueV4JsonV4PDFAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, extras: new string[]{"pdf"});
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.tfd viene vacio.");
        }
        [Fact]
        public async Task IssueJsonV4XMLV1_HashedCustomId_IdDuplicado_Error()
        {
            var build = new BuildSettings();
            IssueJsonV4 issue = new IssueJsonV4(build.Url, build.User, build.Password);
            var customId = Guid.NewGuid().ToString();
            customId = string.Concat(Enumerable.Repeat(customId, 4));
            var json = GetJson(build);
            var response = await issue.TimbrarJsonV1Async(json, customId: customId);
            Assert.True(response.status == "success");
            Assert.True(!String.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
            json = GetJson(build);
            response = await issue.TimbrarJsonV1Async(json, null, customId);
            Assert.True(response.status == "error");
            Assert.True(response.message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.");
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task IssueJsonV4XMLV1_InvalidCustomId_Error()
        {
            var build = new BuildSettings();
            IssueJsonV4 issue = new IssueJsonV4(build.Url, build.User, build.Password);
            var customId = Guid.NewGuid().ToString();
            customId = string.Concat(Enumerable.Repeat(customId, 10));
            var json = GetJson(build);
            var response = await issue.TimbrarJsonV1Async(json, null, customId);
            Assert.True(response.status == "error");
            Assert.True(response.message == "El CustomId no es válido o viene vacío.");
            Assert.Contains("at SW.Helpers.Validation.ValidateCustomId(String customId)", response.messageDetail);
        }
        [Fact]
        public async Task StampJsonV4byTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJson issue = new SW.Services.Issue.IssueJson(build.Url, build.Token);
            var json = GetJson(build);
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json);
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
        private string GetJson(BuildSettings build)
        {
            var file = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/cfdi.json"));
            var json = JObject.Parse(file);
            json["Fecha"] = DateTime.Now.AddHours(-12).ToString("s");
            json["Folio"] = Guid.NewGuid().ToString();
            return json.ToString();
        }

    }
}
