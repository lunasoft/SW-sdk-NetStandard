using System;
using System.Text;
using SW.Services.StampRetention;
using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;
using System.IO;
using Test_SW.Helper;

namespace Test_SW.Services.StampRetention_Test
{
    public class StampRetention_Test
    {
        [Fact]
        public async Task StampRetention_Test_StampRetentionXMLV3Async()
        {
            var build = new BuildSettings();
            StampRetention StampRetention = new StampRetention(build.Url, build.User, build.Password);
            var xmlRetention = GetXmlRetention(build);
            var response = (StampRetentionResponseV3)await StampRetention.TimbrarV3Async(xmlRetention);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Retencion), "El resultado Data.Retention viene vacio.");
        }

        [Fact]
        public async Task StampRetention_Test_StampRetentionXMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampRetention StampRetention = new StampRetention(build.Url, build.Token);
            var xmlRetention = GetXmlRetention(build);
            var response = (StampRetentionResponseV3)await StampRetention.TimbrarV3Async(xmlRetention);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(!string.IsNullOrEmpty(response.Data.Retencion), "El resultado Data.Retention viene vacio.");
        }

        private string GetXmlRetention(BuildSettings build, string fileName = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/RETENTION20/{0}", fileName ?? "retention20.xml")));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword, true);
            return xml;
        }
    }
}
