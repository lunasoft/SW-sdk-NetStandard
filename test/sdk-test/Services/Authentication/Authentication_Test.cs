﻿using SW.Services.Authentication;
using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;

namespace Test_SW.Services.Authentication_Test
{
    public class Authentication_Test
    {
        [Fact]
        public async Task Authentication_Test_ValidateAuthenticationAsync()
        {
            var build = new BuildSettings();
            Authentication auth = new Authentication(build.Url, build.User, build.Password);
            var response = await auth.GetTokenAsync();
            Assert.True(!string.IsNullOrEmpty(response.data.token));
        }
        [Fact]
        public async Task Authentication_Test_ValidateExistUserAsync()
        {
            var build = new BuildSettings();
            var resultExpect = "Falta Capturar Usuario";
            Authentication auth = new Authentication(build.Url, "", build.Password);
            var response = await auth.GetTokenAsync();
            Assert.Equal(response.message, (string)resultExpect);
        }
        [Fact]
        public async Task Authentication_Test_ValidateExistPasswordAsync()
        {
            var build = new BuildSettings();
            var resultExpect = "Falta Capturar Contraseña";
            Authentication auth = new Authentication(build.Url, build.User, "");
            var response = await auth.GetTokenAsync();
            Assert.Equal(response.message, (string)resultExpect);
        }
        [Fact]
        public async Task Authentication_Test_ValidateExistUrlAsync()
        {
            var build = new BuildSettings();
            var resultExpect = "Falta Capturar URL";
            Authentication auth = new Authentication("", build.User, build.Password);
            var response = await auth.GetTokenAsync();
            Assert.Equal(response.message, (string)resultExpect);
        }
    }
}
