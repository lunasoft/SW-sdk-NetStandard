using System;
using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;

namespace Test_SW.Services.Resend
{
    public class Resend_Test
    {
        private readonly BuildSettings _build;
        public Resend_Test()
        {
            _build = new BuildSettings();
        }
        [Fact]
        public async Task ResendEmail_Success()
        {
            SW.Services.Resend.Resend resend = new SW.Services.Resend.Resend(_build.UrlApi, _build.Token);
            var responseResend = await resend.ResendEmailAsync(Guid.Parse("f555f184-6a60-44ce-8531-5ebc997a512e"), "someemail@some.com");
            Assert.NotNull(responseResend);
            Assert.True(responseResend.status.Equals("success"));
            Assert.True(String.IsNullOrEmpty(responseResend.message) &&
                        String.IsNullOrEmpty(responseResend.messageDetail) &&
                        String.IsNullOrEmpty(responseResend.data));
        }
        [Fact]
        public async Task ResendEmail_Auth_Success()
        {
            SW.Services.Resend.Resend resend = new SW.Services.Resend.Resend(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var responseResend = await resend.ResendEmailAsync(Guid.Parse("f555f184-6a60-44ce-8531-5ebc997a512e"), "someemail@some.com");
            Assert.NotNull(responseResend);
            Assert.True(responseResend.status.Equals("success"));
            Assert.True(String.IsNullOrEmpty(responseResend.message) &&
                        String.IsNullOrEmpty(responseResend.messageDetail) &&
                        String.IsNullOrEmpty(responseResend.data));
        }
        [Fact]
        public async Task ResendEmail_Array_Success()
        {
            SW.Services.Resend.Resend resend = new SW.Services.Resend.Resend(_build.UrlApi, _build.Token);
            var emails = new[] 
            { 
                "someemail@some.com",
                "someemail@some.com",
                "someemail@some.com",
                "someemail@some.com",
                "someemail@some.com"
            };
            var responseResend = await resend.ResendEmailAsync(Guid.Parse("f555f184-6a60-44ce-8531-5ebc997a512e"), emails);
            Assert.NotNull(responseResend);
            Assert.True(responseResend.status.Equals("success"));
            Assert.True(String.IsNullOrEmpty(responseResend.message) &&
                        String.IsNullOrEmpty(responseResend.messageDetail) &&
                        String.IsNullOrEmpty(responseResend.data));
        }
        [Fact]
        public async Task ResendEmail_MaxEmails_Error()
        {
            SW.Services.Resend.Resend resend = new SW.Services.Resend.Resend(_build.UrlApi, _build.Token);
            var emails = new[]
            {
                "someemail@some.com",
                "someemail@some.com",
                "someemail@some.com",
                "someemail@some.com",
                "someemail@some.com",
                "someemail@some.com"
            };
            var responseResend = await resend.ResendEmailAsync(Guid.Parse("f555f184-6a60-44ce-8531-5ebc997a512e"), emails);
            Assert.NotNull(responseResend);
            Assert.True(responseResend.status.Equals("error"));
            Assert.True(responseResend.message.Equals("El listado de correos no tiene un formato válido, está vacío o contiene más de 5 correos."));
            Assert.True(!String.IsNullOrEmpty(responseResend.messageDetail));
        }
        [Fact]
        public async Task ResendEmail_InvalidEmail_Error()
        {
            SW.Services.Resend.Resend resend = new SW.Services.Resend.Resend(_build.UrlApi, _build.Token);
            var emails = new[]
            {
                "email@",
                "someemail@some.com"
            };
            var responseResend = await resend.ResendEmailAsync(Guid.Parse("f555f184-6a60-44ce-8531-5ebc997a512e"), emails);
            Assert.NotNull(responseResend);
            Assert.True(responseResend.status.Equals("error"));
            Assert.True(responseResend.message.Equals("El email no tiene un formato válido."));
            Assert.True(!String.IsNullOrEmpty(responseResend.messageDetail));
        }
        [Fact]
        public async Task ResendEmail_InvalidEmail_2_Error()
        {
            SW.Services.Resend.Resend resend = new SW.Services.Resend.Resend(_build.UrlApi, _build.Token);
            var responseResend = await resend.ResendEmailAsync(Guid.Parse("f555f184-6a60-44ce-8531-5ebc997a512e"), "email@");
            Assert.NotNull(responseResend);
            Assert.True(responseResend.status.Equals("error"));
            Assert.True(responseResend.message.Equals("El email no tiene un formato válido."));
            Assert.True(!String.IsNullOrEmpty(responseResend.messageDetail));
        }
        [Fact]
        public async Task ResendEmail_EmptyEmail_Error()
        {
            SW.Services.Resend.Resend resend = new SW.Services.Resend.Resend(_build.UrlApi, _build.Token);
            var responseResend = await resend.ResendEmailAsync(Guid.Parse("f555f184-6a60-44ce-8531-5ebc997a512e"), new string[] { });
            Assert.NotNull(responseResend);
            Assert.True(responseResend.status.Equals("error"));
            Assert.True(responseResend.message.Equals("El listado de correos no tiene un formato válido, está vacío o contiene más de 5 correos."));
            Assert.True(!String.IsNullOrEmpty(responseResend.messageDetail));
        }
    }
}
