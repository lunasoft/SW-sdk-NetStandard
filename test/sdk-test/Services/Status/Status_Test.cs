using Test_SW.Helpers;
using SW.Services.Status;
using Xunit;

namespace Test_SW.Services.Status_Test
{
    public class Status_Test_45
    {
        private string urlSAT = "https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc";

        [Fact]
        public void StatusCFDI_Vigente()
        {
            var build = new BuildSettings();
            Status status = new Status("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc");
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831b");
            Assert.True(response.Estado == "Vigente");
        }
        [Fact]
        public void StatusCFDI_NoEncontrado()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT,120);
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831");
            Assert.Contains("602", response.CodigoEstatus);
        }
        [Fact]
        public void StatusCFDI_ExpresionNoValida()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT);
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "?", "021ea2fb-2254-4232-983b-9808c2ed831");
            Assert.Contains("601", response.CodigoEstatus);
        }
        [Fact]
        public void StatusCFDI_Cancelado()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT);
            var response = status.GetStatusCFDI("LSO1306189R5", "LSO1306189R5", "1.16", "e0aae6b3-43cc-4b9c-b229-7e221000e2bb");
            Assert.True(response.Estado == "Cancelado");
        }
    }
}
