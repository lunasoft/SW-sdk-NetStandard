using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SW.Helpers;
using SW.Services.Stamp;
using Test_SW.Helpers;
using Xunit;
using System.Threading.Tasks;

namespace Test_SW.Services.Stamp_Test
{
    public class Stamp_Test
    {
        [Fact]
        public async Task Stamp_Test_StampXMLV1Async()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV1byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.True(response.status == "success"
                && !string.IsNullOrEmpty(response.data.tfd), "El resultado data.tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV1Base64Async()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, true);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV1Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, true);
            Assert.True(response.status == "success"
              && !string.IsNullOrEmpty(response.data.tfd), response.message);
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2Async()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2Base64Async()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, true);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, true);
            Assert.True(response.status == "success"
              && !string.IsNullOrEmpty(response.data.cfdi), response.message);
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV3Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, true);
            Assert.True(response.status == "success"
               && !string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
        }

        [Fact]
        public async Task Stamp_Test_StampXMLV4byTokenAsync()
        {
            var build = new BuildSettings();
            SW.Services.Stamp.Stamp stamp = new SW.Services.Stamp.Stamp("http://services.test.sw.com.mx", build.Token); //[token] o [usuario, contraseña]
            //URL de pruebas ↑, para productivo usar "https://services.sw.com.mx"
            var xml = GetXml(build);
            //--- para cada xml ejecutar lo siguiente ↓
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml);
            if (response.status != "error")
            {//Si el comprobante se timbró tendrá un status: "success"
                //Datos de la respuesta dependiendo de la versión utilizada para timbrar
                Console.WriteLine(response.data.cadenaOriginalSAT);
                Console.WriteLine(response.data.cfdi);
                Console.WriteLine(response.data.fechaTimbrado);
                Console.WriteLine(response.data.noCertificadoCFDI);
                Console.WriteLine(response.data.noCertificadoSAT);
                Console.WriteLine(response.data.qrCode);
                Console.WriteLine(response.data.selloCFDI);
                Console.WriteLine(response.data.selloSAT);
                Console.WriteLine(response.data.uuid);
            }
            else
            {//En caso de errores por parte del WebService o la librería vendrán como "error"
                //Obtener datos de los errores mediante los campos "message" y "messageDetail"
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }



            Assert.True(response.data != null, "El resultado data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV4Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, true);
            Assert.True(response.data != null, "El resultado data viene vacio." + response.message);
            Assert.True(!string.IsNullOrEmpty(response.data.cfdi), "El resultado data.cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.uuid), "El resultado data.uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloSAT), "El resultado data.selloSAT viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.data.qrCode), "El resultado data.qrCode viene vacio.");
        }
        [Fact]
        public void Stamp_Test_MassStampXMLV4()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            List<string> xmls = new List<string>();
            for (int i = 0; i < 50; i++)
            {
                xmls.Add(GetXml(build));
            }
            var mass_response = stamp.TimbrarV4Async(xmls.ToArray());
            foreach (var dic in mass_response)
            {
                Assert.True(dic.Key != null, "El resultado data viene vacio." + dic.Value.message);
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.cfdi), "El resultado data.cfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.cadenaOriginalSAT), "El resultado data.cadenaOriginalSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.noCertificadoSAT), "El resultado data.noCertificadoSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.noCertificadoCFDI), "El resultado data.noCertificadoCFDI viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.uuid), "El resultado data.uuid viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.selloSAT), "El resultado data.selloSAT viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.selloCFDI), "El resultado data.selloCFDI viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.fechaTimbrado), "El resultado data.fechaTimbrado viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.data.qrCode), "El resultado data.qrCode viene vacio.");
            }
        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var resultExpect = "404";
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url + "/ot", build.Token);
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal(response.message, (string)resultExpect);
            Assert.Equal("error", response.status);
            Assert.Equal("Not Found", response.messageDetail);
        }
        [Fact]
        public async Task Stamp_Test_ValidateFormatTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token + ".");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.status);
            Assert.Contains("El token debe contener 3 partes", response.message);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateExistTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, "");
            var xml = File.ReadAllText("Resources/file.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.status);
            Assert.Contains("El token debe contener 3 partes", response.message);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateEmptyXMLAsync()
        {
            var resultExpect = "Xml CFDI33 no proporcionado o viene vacio.";
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/EmptyXML.xml");
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.status);
            Assert.Equal(response.message, (string)resultExpect);
            Assert.True(string.IsNullOrEmpty(response.messageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateSpecialCharactersFromXMLAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = File.ReadAllText("Resources/SpecialCharacters.xml");
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            var response = await stamp.TimbrarV1Async(xml);
            Assert.True(response.status == "success", "Result not expected. Error: " + response.message);
            Assert.False(string.IsNullOrEmpty(response.data.tfd), "Result not expected. Error: " + response.message);
        }
        [Fact]
        public async Task Stamp_Test_ValidateIsUTF8FromXMLAsync()
        {
            var resultExpect = "301";
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/fileANSI.xml"));            
            var response = await stamp.TimbrarV1Async(xml);
            Assert.True(response.message.Contains(resultExpect), "Result not expected. Error: " + response.message);
            Assert.Contains("Error al leer el documento XML. La estructura del documento no es un Xml valido", response.messageDetail);
        }
        [Fact]
        public async Task Stamp_Test_MultipleStampXMLV1byTokenAsync()
        {
            var build = new BuildSettings();
            var resultExpect = false;
            int iterations = 10;
            Stamp stamp = new Stamp(build.Url, build.Token);
            List<StampResponseV1> listXmlResult = new List<StampResponseV1>();
            for (int i = 0; i < iterations; i++)
            {
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
                xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
                listXmlResult.Add(response);
            }
            if (listXmlResult != null)
                resultExpect = listXmlResult.FindAll(w => w.status == ResponseType.success.ToString() || w.message.Contains("72 horas")).Count == iterations;

            Assert.True((bool)resultExpect);
        }
        private string GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/file.xml"));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
