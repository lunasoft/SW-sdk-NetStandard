using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SW.Helpers;
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
            _build= new BuildSettings();
        }
        [Fact]
        public async Task Storage_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.True(response.status.Equals("success"));
            Assert.NotNull(response.data);
            Assert.True(response.data.records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlXml));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlPdf));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCancellation));
        }
        [Fact]
        public async Task Storage_Auth_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.True(response.status.Equals("success"));
            Assert.NotNull(response.data);
            Assert.True(response.data.records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlXml));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlPdf));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCancellation));
        }
        [Fact]
        public async Task StorageExtras_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.True(response.status.Equals("success"));
            Assert.NotNull(response.data);
            Assert.True(response.data.records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlXml));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlPdf));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCancellation));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].uuid));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].formaPago));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].condicionesPago));
            Assert.True(response.data.records[0].descuento >= 0);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].emisorNombre));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].emisorRfc));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].fecha));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].fechaTimbrado));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].version));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].usoCFDI));
            Assert.True(response.data.records[0].trasladosIVA >= 0);
            Assert.True(response.data.records[0].trasladosIEPS >= 0);
            Assert.True(response.data.records[0].retencionesIEPS >= 0);
            Assert.True(response.data.records[0].retencionesISR >= 0);
            Assert.True(response.data.records[0].retencionesIVA >= 0);
            Assert.True(response.data.records[0].totalImpuestosLocalesRetencion >= 0);
            Assert.True(response.data.records[0].totalImpuestosLocalesTraslados >= 0);
            Assert.True(response.data.records[0].totalImpuestosRetencion >= 0);
            Assert.True(response.data.records[0].totalImpuestosTraslados >= 0);
            Assert.True(response.data.records[0].total >= 0);
            Assert.True(response.data.records[0].subTotal >= 0);
            Assert.True(response.data.records[0].status);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].serie));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].luegarExpedicion));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].selloCFD));
        }
        [Fact]
        public async Task StorageExtras_Auth_Success()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.True(response.status.Equals("success"));
            Assert.NotNull(response.data);
            Assert.True(response.data.records.Count > 0);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlXml));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCfdi));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlPdf));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].urlAckCancellation));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].uuid));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].formaPago));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].condicionesPago));
            Assert.True(response.data.records[0].descuento >= 0);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].emisorNombre));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].emisorRfc));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].fecha));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].fechaTimbrado));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].version));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].usoCFDI));
            Assert.True(response.data.records[0].trasladosIVA >= 0);
            Assert.True(response.data.records[0].trasladosIEPS >= 0);
            Assert.True(response.data.records[0].retencionesIEPS >= 0);
            Assert.True(response.data.records[0].retencionesISR >= 0);
            Assert.True(response.data.records[0].retencionesIVA >= 0);
            Assert.True(response.data.records[0].totalImpuestosLocalesRetencion >= 0);
            Assert.True(response.data.records[0].totalImpuestosLocalesTraslados >= 0);
            Assert.True(response.data.records[0].totalImpuestosRetencion >= 0);
            Assert.True(response.data.records[0].totalImpuestosTraslados >= 0);
            Assert.True(response.data.records[0].total >= 0);
            Assert.True(response.data.records[0].subTotal >= 0);
            Assert.True(response.data.records[0].status);
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].serie));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].luegarExpedicion));
            Assert.True(!String.IsNullOrEmpty(response.data.records[0].selloCFD));
        }
        [Fact]
        public async Task Storage_Token_Error()
        {
            Storage storage = new(_build.UrlApi, "token");
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("El token debe contener 3 partes"));
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Storage_Auth_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, "password");
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("AU4101 - El token proporcionado viene vacio."));
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task StorageExtras_Token_Error()
        {
            Storage storage = new(_build.UrlApi, "token");
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("El token debe contener 3 partes"));
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task StorageExtras_Auth_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Url, _build.User, "password");
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("AU4101 - El token proporcionado viene vacio."));
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Storage_NotFound_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("No se encuentra registro del timbrado."));
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task StorageExtras_NotFound_Error()
        {
            Storage storage = new(_build.UrlApi, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("No se encuentra registro del timbrado."));
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Storage_WrongUrlApi_Error()
        {
            Storage storage = new(_build.Url, _build.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("404"));
            Assert.True(response.messageDetail.Equals("Not Found"));
        }
        [Fact]
        public async Task StorageExtras_WrongUrlApi_Error()
        {
            Storage storage = new(_build.Url, _build.Token);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.NotNull(response);
            Assert.True(response.status.Equals("error"));
            Assert.True(response.message.Equals("404"));
            Assert.True(response.messageDetail.Equals("Not Found"));
        }
    }
}
