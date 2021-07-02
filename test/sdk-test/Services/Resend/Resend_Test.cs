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
            var responseResend = await resend.ResendEmailAsync("1b1ab944-174a-4c1c-8319-da66d269dfb7", "someemail@some.com");
            Assert.True(responseResend != null && responseResend.data != null && responseResend.status == "success");
        }
    }
}
