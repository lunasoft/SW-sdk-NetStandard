using Test_SW.Helpers;
using SW.Services.Pendings;
using Xunit;
using System.Threading.Tasks;
using Test_SW.Helper;

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
            Assert.True(response.Message.Contains((string)resultExpect) || response.Status != "success");
        }
        [Fact (Skip = "Intermitencia del SAT en cancelaciones.")]
        public async Task RelationsByRfcUuidAsync()
        {
            var build = new BuildSettings();
            Pending pendientes = new Pending(build.Url, build.User, build.Password);
            PendingsResponse response = await pendientes.PendingsByRfcAsync(build.Rfc);
            CustomAssert.SuccessResponse(response, response.Data);
        }
    }
}
