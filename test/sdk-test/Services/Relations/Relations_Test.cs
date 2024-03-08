using Test_SW.Helpers;
using SW.Services.Relations;
using Xunit;
using System.Threading.Tasks;
using Test_SW.Helper;

namespace Test_SW.Services.Relations_Test
{
    public class Relations_Test
    {
        [Fact(Skip = "Constant changes of UUID")]
        public async Task ValidateParametersAsync()
        {
            var resultExpect = "El UUID proporcionado inválido. Favor de verificar.";
            var build = new BuildSettings();
            Relations relations = new Relations(build.Url, build.User, build.Password);
            RelationsResponse response = await relations.RelationsByCSDAsync(build.Cer, build.Key, build.Rfc, build.CerPassword, "");
            Assert.Contains((string)resultExpect, response.MessageDetail);
        }
        [Fact(Skip = "Constant changes of UUID")]
        public async Task RelationsByRfcUuidAsync()
        {
            var build = new BuildSettings();
            Relations relations = new Relations(build.Url, build.User, build.Password);
            RelationsResponse response = await relations.RelationsByRfcUuidAsync(build.Rfc, "31c885c8-6dcb-4d82-9cfd-01707c828c50");
            CustomAssert.SuccessResponse(response, response.Data);
        }
        [Fact(Skip = "Constant changes of UUID")]
        public async Task RelationsByCSDAsync()
        {
            var build = new BuildSettings();
            Relations relations = new Relations(build.Url, build.User, build.Password);
            RelationsResponse response = await relations.RelationsByCSDAsync(build.Cer, build.Key, build.Rfc, build.CerPassword, "31c885c8-6dcb-4d82-9cfd-01707c828c50");
            CustomAssert.SuccessResponse(response, response.Data);
        }
        [Fact(Skip = "Constant changes of UUID")]
        public async Task RelationsRejectByPfxAsync()
        {
            var build = new BuildSettings();
            Relations relations = new Relations(build.Url, build.User, build.Password);
            RelationsResponse response = await relations.RelationsByPFXAsync(build.Pfx, build.Rfc, build.CerPassword, "31c885c8-6dcb-4d82-9cfd-01707c828c50");
            CustomAssert.SuccessResponse(response, response.Data);
        }
        [Fact(Skip = "Constant changes of UUID")]
        public async Task RelationsByXmlAsync()
        {
            var build = new BuildSettings();
            Relations relations = new Relations(build.Url, build.User, build.Password);
            RelationsResponse response = await relations.RelationsByXMLAsync(build.RelationsXML);
            CustomAssert.SuccessResponse(response, response.Data);
        }
    }
}
