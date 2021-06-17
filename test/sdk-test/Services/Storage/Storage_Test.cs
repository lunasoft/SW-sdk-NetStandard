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
        [Fact]
        public async Task Storage_Test_GetByUUIDAsync()
        {
            var build = new BuildSettings();
            Storage storage = new Storage(build.UrlSWServices, build.Token);
            var response = (StorageResponse)await storage.GetByUUIDAsync(new Guid("05ed3287-a364-4d94-b9ae-33b2c4384059"));
            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(response.data.records != null, "El resultado records viene vacio.");
            Assert.True(response.data.records.Count > 0, "El resultado records viene vacio.");
            Assert.True(response.data.records[0].urlXml != null, "Url no encontrada.");
        }
    }
}
