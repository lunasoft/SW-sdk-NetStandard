using System;
using Test_SW.Helpers;
using SW.Services.Pendings;
using Xunit;
using System.Threading.Tasks;

namespace Test_SW.Services.Pendings
{
    public class Pendings_Test
    {
        
        [Fact]
        public async Task ValidateParametersAsync()
        {
            var resultExpect = "CA1101 - No existen peticiones para el RFC Receptor.";
            var build = new BuildSettings();
            Pending pendientes = new Pending(build.Url, build.User, build.Password);
            var response = await pendientes.PendingsByRfcAsync("Test");
            Assert.True(response.message.Contains((string)resultExpect) || response.status != "success");
        }
        [Fact (Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task RelationsByRfcUuidAsync()
        {
            var build = new BuildSettings();
            Pending pendientes = new Pending(build.Url, build.User, build.Password);
            PendingsResponse response = await pendientes.PendingsByRfcAsync(build.Rfc);
            Assert.True(response.status == "success");
        }
    }
}
