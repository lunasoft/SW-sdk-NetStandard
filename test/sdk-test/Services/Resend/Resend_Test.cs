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
            var responseResend = await resend.ResendEmailAsync("f555f184-6a60-44ce-8531-5ebc997a512e", "someemail@some.com");
            Assert.True(responseResend != null && responseResend.data != null && responseResend.status == "success");
        }
    }
}
