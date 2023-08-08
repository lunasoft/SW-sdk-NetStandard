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
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task IssueJsonV2Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJson issue = new SW.Services.Issue.IssueJson(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV2)await issue.TimbrarJsonV2Async(json);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task IssueJsonV3Async()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJson issue = new SW.Services.Issue.IssueJson(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV3)await issue.TimbrarJsonV3Async(json);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        [Fact]
        public async Task IssueV4JsonV4fAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "someemail@some.com");
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task IssueV4JsonV4CustomIdfAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var customNumber = new Random().Next(1000, 10000).ToString();
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "someemail@some.com", customNumber);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
            response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "someemail@some.com", customNumber);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task IssueV4JsonV4MultipleEmailAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var customNumber = new Random().Next(1000, 10000).ToString();
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, "email1@abcdfg.com,email2@abcdfg.com", customNumber);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task IssueV4JsonV4PDFAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJsonV4 issue = new SW.Services.Issue.IssueJsonV4(build.Url, build.User, build.Password);
            var json = GetJson(build);
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json, extras: new string[] { "pdf" });
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Tfd viene vacio.");
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
            Assert.True(response.Status == "success");
            Assert.True(!String.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
            json = GetJson(build);
            response = await issue.TimbrarJsonV1Async(json, null, customId);
            Assert.NotNull(response);
            Assert.True(response.Status == "error");
            Assert.True(response.Message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.");
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
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
            Assert.NotNull(response);
            Assert.True(response.Status == "error");
            Assert.True(response.Message == "El CustomId no es válido o viene vacío.");
            Assert.Contains("at SW.Helpers.Validation.ValidateCustomId(String customId)", response.MessageDetail);
        }
        [Fact]
        public async Task StampJsonV4byTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Issue.IssueJson issue = new SW.Services.Issue.IssueJson(build.Url, build.Token);
            var json = GetJson(build);
            var response = (StampResponseV4)await issue.TimbrarJsonV4Async(json);
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
        private string GetJson(BuildSettings build)
        {
            var file = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/cfdi40.json"));
            var json = JObject.Parse(file);
            json["Fecha"] = DateTime.Now.AddHours(-12).ToString("s");
            json["Folio"] = Guid.NewGuid().ToString();
            return json.ToString();
        }
    }
}
