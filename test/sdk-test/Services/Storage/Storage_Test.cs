using System;
using SW.Services.Storage;
using Test_SW.Helpers;
using Xunit;
using System.Threading.Tasks;

namespace Test_SW.Services.Storage_Test
{
    public class Storage_Test
    {
        private readonly BuildSettings _build;
        public Storage_Test()
        {
            _build = new BuildSettings();
        }
        [Fact]
        public async Task Storage_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.True(response.Status.Equals("success"));
            Assert.NotNull(response.Data);
            Assert.True(response.Data.Records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
        }
        [Fact]
        public async Task Storage_Auth_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var response = await storage.GetXmlAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.True(response.Status.Equals("success"));
            Assert.NotNull(response.Data);
            Assert.True(response.Data.Records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
        }
        [Fact]
        public async Task StorageExtras_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.True(response.Status.Equals("success"));
            Assert.NotNull(response.Data);
            Assert.True(response.Data.Records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Uuid));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].FormaPago));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].CondicionesPago));
            Assert.True(response.Data.Records[0].Descuento >= 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].EmisorNombre));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].EmisorRfc));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Fecha));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].FechaTimbrado));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Version));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UsoCfdi));
            Assert.True(response.Data.Records[0].TrasladosIva >= 0);
            Assert.True(response.Data.Records[0].TrasladosIeps >= 0);
            Assert.True(response.Data.Records[0].RetencionesIeps >= 0);
            Assert.True(response.Data.Records[0].RetencionesIsr >= 0);
            Assert.True(response.Data.Records[0].RetencionesIva >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosLocalesRetencion >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosLocalesTraslados >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosRetencion >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosTraslados >= 0);
            Assert.True(response.Data.Records[0].Total >= 0);
            Assert.True(response.Data.Records[0].SubTotal >= 0);
            Assert.True(response.Data.Records[0].Status);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Serie));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].LuegarExpedicion));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].SelloCfd));
        }
        [Fact]
        public async Task StorageExtras_Auth_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.True(response.Status.Equals("success"));
            Assert.NotNull(response.Data);
            Assert.True(response.Data.Records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Uuid));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].FormaPago));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].CondicionesPago));
            Assert.True(response.Data.Records[0].Descuento >= 0);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].EmisorNombre));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].EmisorRfc));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Fecha));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].FechaTimbrado));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Version));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].UsoCfdi));
            Assert.True(response.Data.Records[0].TrasladosIva >= 0);
            Assert.True(response.Data.Records[0].TrasladosIeps >= 0);
            Assert.True(response.Data.Records[0].RetencionesIeps >= 0);
            Assert.True(response.Data.Records[0].RetencionesIsr >= 0);
            Assert.True(response.Data.Records[0].RetencionesIva >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosLocalesRetencion >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosLocalesTraslados >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosRetencion >= 0);
            Assert.True(response.Data.Records[0].TotalImpuestosTraslados >= 0);
            Assert.True(response.Data.Records[0].Total >= 0);
            Assert.True(response.Data.Records[0].SubTotal >= 0);
            Assert.True(response.Data.Records[0].Status);
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].Serie));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].LuegarExpedicion));
            Assert.True(!String.IsNullOrEmpty(response.Data.Records[0].SelloCfd));
        }
        [Fact]
        public async Task Storage_Token_Error()
        {
            Storage storage = new(_build.UrlApi, "token");
            var response = await storage.GetXmlAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("El token debe contener 3 partes"));
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Storage_Auth_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, "password");
            var response = await storage.GetXmlAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("AU4101 - El token proporcionado viene vacio."));
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task StorageExtras_Token_Error()
        {
            Storage storage = new(_build.UrlApi, "token");
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("El token debe contener 3 partes"));
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task StorageExtras_Auth_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, "password");
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("AU4101 - El token proporcionado viene vacio."));
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Storage_NotFound_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("d52cc816-b833-49d2-7e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("No se encuentra registro del timbrado."));
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task StorageExtras_NotFound_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("d52cc816-b833-49d2-7e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("No se encuentra registro del timbrado."));
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Storage_WrongUrlApi_Error()
        {
            Storage storage = new(_build.Url, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("404"));
            Assert.True(response.MessageDetail.Equals("Not Found"));
        }
        [Fact]
        public async Task StorageExtras_WrongUrlApi_Error()
        {
            Storage storage = new(_build.Url, _build.Token);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("d52cc816-b833-49d2-8e41-1a540e36f38f"));
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("error"));
            Assert.True(response.Message.Equals("404"));
            Assert.True(response.MessageDetail.Equals("Not Found"));
        }
    }
}
