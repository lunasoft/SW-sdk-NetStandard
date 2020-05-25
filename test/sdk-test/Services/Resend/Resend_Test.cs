using sw_sdk.Services.Resend;
using System;
using System.Collections.Generic;
using System.Text;
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
            sw_sdk.Services.Resend.Resend resend = new sw_sdk.Services.Resend.Resend(build.Url, build.UrlPdf, build.User, build.Password);
            var responseResend = await resend.ResendEmailAsync("d48e3be0-14b5-479c-8499-6a76df824ce0", "someemail@some.com");
            Assert.True(responseResend.data != null && responseResend.status == "success");
        }
    }
}
