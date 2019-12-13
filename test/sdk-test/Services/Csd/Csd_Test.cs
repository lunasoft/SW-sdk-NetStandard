using Test_SW.Helpers;
using SW.Services.Csd;
using Xunit;
using System.Threading.Tasks;

namespace Test_SW_sdk.Services.Csd
{
    public class Csd_Test
    {
        [Fact]
        public async Task Csd_Test_UploadCsdAsync()
        {
            var build = new BuildSettings();
            CsdUtils csd = new CsdUtils(build.Url, build.User, build.Password);
            var response = await csd.UploadMyCsdAsync(build.Cer, build.Key, build.CerPassword, "stamp", true);
            Assert.True(response.data != null && response.status == "success");
        }
        [Fact]
        public async Task Csd_Test_UploadCsd_EmptyCsdAsync()
        {
            var build = new BuildSettings();
            CsdUtils csd = new CsdUtils(build.Url, build.User, build.Password);
            var response = await csd.UploadMyCsdAsync("", build.Key, build.CerPassword, "stamp", true);
            Assert.True(response.message == "El certificado o llave privada vienen vacios" && response.status == "error");
        }
    }
}
