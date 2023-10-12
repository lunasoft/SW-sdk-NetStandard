using SW.Helpers;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class StampService : Services
    {
        protected StampService(string url, string user, string password, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
        }
        protected StampService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
        }
        internal virtual MultipartFormDataContent GetMultipartContent(byte[] xml, bool isZip = false)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();

            if (isZip)
            {
                var memoryStream = new MemoryStream();
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var zipEntry = zipArchive.CreateEntry("archivo.xml", CompressionLevel.Fastest);
                    using (var entryStream = zipEntry.Open())
                    {
                        entryStream.Write(xml, 0, xml.Length);
                    }
                }
                memoryStream.Position = 0;
                var fileContent = new StreamContent(memoryStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
                content.Add(fileContent, "xml", "archivo.zip");
            }
            else
            {
                ByteArrayContent fileContent = new ByteArrayContent(xml);
                content.Add(fileContent, "xml", "xml");
            }

            return content;
        }
    }
}
