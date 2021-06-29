using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;

namespace sdk_test.Services.Resend
{
    public class Resend_Test
    {
        [Fact(Skip = "bug SMARTER-2687")]
        public async Task Resend_email()
        {
            var build = new BuildSettings();
            sw_sdk.Services.Resend.Resend resend = new sw_sdk.Services.Resend.Resend(build.Url, build.UrlSWServices, build.User, build.Password);
            var responseResend = await resend.ResendEmailAsync("534a129c-2a8d-4868-8f51-1fd64040ee97", "someemail@some.com");
            Assert.True(responseResend != null && responseResend.data != null && responseResend.status == "success");
        }
    }
}
