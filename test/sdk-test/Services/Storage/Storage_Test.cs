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
            var response = (StorageResponse)await storage.GetByUUIDAsync(new Guid("534a129c-2a8d-4868-8f51-1fd64040ee97"));
            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(response.data.records != null, "El resultado records viene vacio.");
            Assert.True(response.data.records.Count > 0, "El resultado records viene vacio.");
            Assert.True(response.data.records[0].urlXml != null, "Url no encontrada.");
        }
    }
}
