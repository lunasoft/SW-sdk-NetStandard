using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;

namespace sdk_test.Services.Resend
{
    public class Resend_Test
    {
        [Fact]
        public async Task Resend_email()
        {
            var build = new BuildSettings();
            sw_sdk.Services.Resend.Resend resend = new sw_sdk.Services.Resend.Resend(build.Url, build.UrlSWServices, build.User, build.Password);
            var responseResend = await resend.ResendEmailAsync("3f946ad4-8a35-4067-8dc7-5227a80f6938", "someemail@some.com");
            Assert.True(responseResend != null && responseResend.data != null && responseResend.status == "success");
        }
    }
}
