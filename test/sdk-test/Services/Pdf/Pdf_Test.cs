using SW.Services.Stamp;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Test_SW.Helpers;
using Xunit;

namespace sdk_test.Services.Pdf
{
    public class Pdf_Test
    {
        [Fact]
        public async Task PDf_Test_Generate()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if(response.status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.Url, build.UrlPdf, build.User, build.Password, 8888, "127.0.0.1");
                var responsePdf = await pdf.GenerarPdfAsync(response.data.cfdi, build.templateId);
                Assert.True(responsePdf.data != null && responsePdf.status == "success");
            }
            else
            {
                Assert.True(false);
            }
            
        }
        [Fact]
        public async Task PDf_Test_Generate_Token()
        {
            var build = new BuildSettings();
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlPdf, build.Token, 8888, "127.0.0.1");
                var responsePdf = await pdf.GenerarPdfAsync(response.data.cfdi, build.templateId);
                Assert.True(responsePdf.data != null && responsePdf.status == "success");
            }
            else
            {
                Assert.True(false);
            }

        }

        static Random randomNumber = new Random(1);
        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/fileIssue.xml"));
            xml = Test_SW.Helpers.SignTools.RemoverCaracteresInvalidosXml(xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("Fecha", DateTime.Now.AddHours(-12).ToString("s"));
            doc.DocumentElement.SetAttribute("Folio", DateTime.Now.Ticks.ToString() + randomNumber.Next(100));
            xml = doc.OuterXml;
            return xml;
        }
    }
}
