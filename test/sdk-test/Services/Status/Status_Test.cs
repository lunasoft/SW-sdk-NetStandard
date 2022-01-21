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
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831b", "WBjHe+9loaYIMM5wYwLxfhT6FnotG0KLRNheOlIxXoVMvsafsRdWY/aZkqPmYCbjyWVrdLN5120ThjlGPcUGcziOnHXfklslpW3aMu2RVAB8Lp95baMs+a7eTlzh4QcvU5eXYlzxGVIW+64UNQpAK2ssurE+1+7a/CUZeq7fdSLMKdwxulWaSADA+4le6QI16Lb/eLD+oJ+X8/zAT4KfYw5L/eRkOoAzrPpDFeydQq8dzTljPFRoHvsguZf4WrbOcyYqUzo9EiZl7bVuxDb0X6sV/Kn9ZKAEXhIyXbcGzVhJB3MM1Zi5Yh+zxvnzYXcE9pXCRp4ff7kvOpzyvtsNVA==");
            Assert.True(response.Estado == "Vigente");
        }
        [Fact]
        public void StatusCFDI_NoEncontrado()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT,120);
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831", "WBjHe+9loaYIMM5wYwLxfhT6FnotG0KLRNheOlIxXoVMvsafsRdWY/aZkqPmYCbjyWVrdLN5120ThjlGPcUGcziOnHXfklslpW3aMu2RVAB8Lp95baMs+a7eTlzh4QcvU5eXYlzxGVIW+64UNQpAK2ssurE+1+7a/CUZeq7fdSLMKdwxulWaSADA+4le6QI16Lb/eLD+oJ+X8/zAT4KfYw5L/eRkOoAzrPpDFeydQq8dzTljPFRoHvsguZf4WrbOcyYqUzo9EiZl7bVuxDb0X6sV/Kn9ZKAEXhIyXbcGzVhJB3MM1Zi5Yh+zxvnzYXcE9pXCRp4ff7kvOpzyvtsNVA==");
            Assert.Contains("602", response.CodigoEstatus);
        }
        [Fact]
        public void StatusCFDI_ExpresionNoValida()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT);
            var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "?", "021ea2fb-2254-4232-983b-9808c2ed831", "1234");
            Assert.Contains("601", response.CodigoEstatus);
        }
        [Fact]
        public void StatusCFDI_Cancelado()
        {
            var build = new BuildSettings();
            Status status = new Status(urlSAT);
            var response = status.GetStatusCFDI("LSO1306189R5", "XAXX010101000", "0.50", "48face02-7352-4120-bcea-1563ab23968b", "WBjHe+9loaYIMM5wYwLxfhT6FnotG0KLRNheOlIxXoVMvsafsRdWY/aZkqPmYCbjyWVrdLN5120ThjlGPcUGcziOnHXfklslpW3aMu2RVAB8Lp95baMs+a7eTlzh4QcvU5eXYlzxGVIW+64UNQpAK2ssurE+1+7a/CUZeq7fdSLMKdwxulWaSADA+4le6QI16Lb/eLD+oJ+X8/zAT4KfYw5L/eRkOoAzrPpDFeydQq8dzTljPFRoHvsguZf4WrbOcyYqUzo9EiZl7bVuxDb0X6sV/Kn9ZKAEXhIyXbcGzVhJB3MM1Zi5Yh+zxvnzYXcE9pXCRp4ff7kvOpzyvtsNVA==");
            Assert.True(response.Estado == "Cancelado");
        }
    }
}
