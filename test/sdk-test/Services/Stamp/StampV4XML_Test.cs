using System;
using System.IO;
using System.Text;
using SW.Services.Stamp;
using Test_SW.Helpers;
using Xunit;
using System.Threading.Tasks;

namespace Test_SW.Services.Stamp_Test
{
    public class StampV4XML_Test
    {
        [Fact]
        public async Task Stamp_Test_StampV4XMLV4_SameCustomID_byTokenAsync()
        {
            string CustomId = Guid.NewGuid().ToString();
            var build = new BuildSettings();
            BaseStampV4XML stamp = new StampV4XML(build.Url, build.UrlSWServices, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2XMLAsync(xml,null ,CustomId);
            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");

            xml = GetXml(build);
            response = (StampResponseV2)await stamp.TimbrarV2XMLAsync(xml,null ,CustomId);
            Assert.True(response.status == "error" && response.message == "CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.");
        }

        [Fact]
        public async Task Stamp_Test_StampV4XMLV4_DifCustomID_byTokenAsync()
        {
            string CustomIdfirstRequest = Guid.NewGuid().ToString();
            string CustomIdSecondRequest = Guid.NewGuid().ToString();
            var build = new BuildSettings();
            BaseStampV4XML stamp = new StampV4XML(build.Url, build.UrlSWServices ,build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2XMLAsync(xml,null ,CustomIdfirstRequest);
            Assert.True(response.data != null, "El resultado data viene vacio.");

            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            response = (StampResponseV2)await stamp.TimbrarV2XMLAsync(xml,null ,CustomIdSecondRequest);

            Assert.True(response.status == "error" && response.message == "307. El comprobante contiene un timbre previo.");
        }

        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.CerPassword);
            return xml;
        }
    }
}
