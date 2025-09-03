using System;
using System.Text;
using SW.Services.StampRetention;
using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;
using System.IO;
using Test_SW.Helper;
using SW.Services.Stamp;

namespace Test_SW.Services.StampRetention_Test
{
    public class StampRetention_Test
    {
        private readonly BuildSettings _build;
        private readonly String _message307;
        private readonly String _messageAuth;
        public StampRetention_Test()
        {
            _build = new BuildSettings();
            _message307 = "307. El comprobante contiene un timbre previo.";
            _messageAuth = "401 - El rango de la fecha de generación no debe de ser mayor a 72 horas para la emisión del timbre.";
        }


        [Fact]
        public async Task StampRetention_Test_StampRetentionXMLV3Async()
        {
            var build = new BuildSettings();
            StampRetention StampRetention = new StampRetention(_build.Url, _build.User, _build.Password);
            var xmlRetention = GetXmlRetention(build);
            var response = (StampRetentionResponseV3)await StampRetention.TimbrarV3Async(xmlRetention);
            if (response.Status == "error")
            {
                Assert.True(response.Message == _message307 || response.Message == _messageAuth);
            }
            else
            {
                CustomAssert.SuccessResponse(response, response.Data);
                Assert.True(!string.IsNullOrEmpty(response.Data.Retencion), "El resultado Data.Retention viene vacio.");
            }
        }

        [Fact]
        public async Task StampRetention_Test_StampRetentionXMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            StampRetention StampRetention = new StampRetention(_build.Url, _build.Token);
            var xmlRetention = GetXmlRetention(build);
            var response = (StampRetentionResponseV3)await StampRetention.TimbrarV3Async(xmlRetention);
            if (response.Status == "error")
            {
                Assert.True(response.Message == _message307 || response.Message == _messageAuth);
            }
            else
            {
                CustomAssert.SuccessResponse(response, response.Data);
                Assert.True(!string.IsNullOrEmpty(response.Data.Retencion), "El resultado Data.Retention viene vacio.");
            }
        }

        [Fact]
        public async Task StampRetention_Test_ValidateFormatTokenAsync()
        {
            var build = new BuildSettings();
            StampRetention StampRetention = new StampRetention(_build.Url, _build.Token + ".");
            var xmlRetention = GetXmlRetention(build);
            var response = await StampRetention.TimbrarV3Async(xmlRetention);
            CustomAssert.ErrorResponse(response);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }

        [Fact]
        public async Task StampRetention_Test_ValidateEmptyXMLAsync()
        {
            var build = new BuildSettings();
            StampRetention StampRetention = new StampRetention(_build.Url, _build.Token);
            var response = await StampRetention.TimbrarV3Async(String.Empty);
            CustomAssert.ErrorResponse(response);
            Assert.Equal("301 - La estructura del comprobante es incorrecta.", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }

        [Fact(Skip = "Change of UT for sign")]
        public async Task StampRetention_Test_StampRetentionXMLV3_XMLDuplicado_Error()
        {
            var build = new BuildSettings();
            StampRetention StampRetention = new StampRetention(_build.Url, _build.Token);
            var xmlRetention = GetXmlRetention(build);
            var response = await StampRetention.TimbrarV3Async(xmlRetention);
            CustomAssert.SuccessResponse(response, response.Data);
            response = await StampRetention.TimbrarV3Async(xmlRetention);
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message == "307. El comprobante contiene un timbre previo.");
        }

        private string GetXmlRetention(BuildSettings build, string fileName = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/RETENTION20/{0}", fileName ?? "retention20.xml")));
            return xml;
        }
    }
}
