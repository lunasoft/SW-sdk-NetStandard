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
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV1byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV1Base64Async()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, true);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV1Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, true);
            Assert.True(response.Status == "success"
              && !string.IsNullOrEmpty(response.Data.Tfd), response.Message);
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2Async()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2Base64Async()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, true);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV2Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV2)await stamp.TimbrarV2Async(xml, true);
            Assert.True(response.Status == "success"
              && !string.IsNullOrEmpty(response.Data.Cfdi), response.Message);
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV3byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV3Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV3)await stamp.TimbrarV3Async(xml, true);
            Assert.True(response.Status == "success"
               && !string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
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
            if (response.Status != "error")
            {//Si el comprobante se timbró tendrá un Status: "success"
                //Datos de la respuesta dependiendo de la versión utilizada para timbrar
                Console.WriteLine(response.Data.CadenaOriginalSat);
                Console.WriteLine(response.Data.Cfdi);
                Console.WriteLine(response.Data.FechaTimbrado);
                Console.WriteLine(response.Data.NoCertificadoCfdi);
                Console.WriteLine(response.Data.NoCertificadoSat);
                Console.WriteLine(response.Data.QrCode);
                Console.WriteLine(response.Data.SelloCfdi);
                Console.WriteLine(response.Data.SelloSat);
                Console.WriteLine(response.Data.Uuid);
            }
            else
            {//En caso de errores por parte del WebService o la librería vendrán como "error"
                //Obtener datos de los errores mediante los campos "Message" y "MessageDetail"
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }



            Assert.True(response.Data != null, "El resultado Data viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_StampXMLV4Base64byTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV4)await stamp.TimbrarV4Async(xml, true);
            Assert.True(response.Data != null, "El resultado Data viene vacio." + response.Message);
            Assert.True(!string.IsNullOrEmpty(response.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.Uuid), "El resultado Data.Uuid viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
            Assert.True(!string.IsNullOrEmpty(response.Data.QrCode), "El resultado Data.QrCode viene vacio.");
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
                Assert.True(dic.Key != null, "El resultado Data viene vacio." + dic.Value.Message);
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.Cfdi), "El resultado Data.Cfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.CadenaOriginalSat), "El resultado Data.CadenaOriginalSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.NoCertificadoSat), "El resultado Data.NoCertificadoSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.NoCertificadoCfdi), "El resultado Data.NoCertificadoCfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.Uuid), "El resultado Data.Uuid viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.SelloSat), "El resultado Data.SelloSat viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.SelloCfdi), "El resultado Data.SelloCfdi viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.FechaTimbrado), "El resultado Data.FechaTimbrado viene vacio.");
                Assert.True(!string.IsNullOrEmpty(dic.Value.Data.QrCode), "El resultado Data.QrCode viene vacio.");
            }
        }
        [Fact]
        public async Task Stamp_Test_TimbrarV1TooLongAsync()
        {
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build, "70000conceptos.xml");
            var response = (StampResponseV1)await stamp.TimbrarV1TooLongAsync(xml);
            Assert.True(response.Status == "success"
                && !string.IsNullOrEmpty(response.Data.Tfd), "El resultado Data.Tfd viene vacio.");
        }
        [Fact]
        public async Task Stamp_Test_ValidateServerErrorAsync()
        {
            var resultExpect = "404";
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url + "/ot", build.Token);
            var xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal(response.Message, (string)resultExpect);
            Assert.Equal("error", response.Status);
            Assert.Equal("Not Found", response.MessageDetail);
        }
        [Fact]
        public async Task Stamp_Test_ValidateFormatTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token + ".");
            var xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateExistTokenAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, "");
            var xml = GetXml(build);
            var response = await stamp.TimbrarV1Async(xml);
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Contains("El token debe contener 3 partes", response.Message);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateEmptyXMLAsync()
        {
            var resultExpect = "Xml CFDI33 no proporcionado o viene vacio.";
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var response = await stamp.TimbrarV1Async(String.Empty);
            Assert.NotNull(response);
            Assert.Equal("error", response.Status);
            Assert.Equal(response.Message, (string)resultExpect);
            Assert.True(string.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task Stamp_Test_ValidateSpecialCharactersFromXMLAsync()
        {
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = GetXml(build, "cfdi40_specialchar.xml");
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            var response = await stamp.TimbrarV1Async(xml);
            Assert.True(response.Status == "success", "Result not expected. Error: " + response.Message);
            Assert.False(string.IsNullOrEmpty(response.Data.Tfd), "Result not expected. Error: " + response.Message);
        }
        [Fact]
        public async Task Stamp_Test_ValidateIsUTF8FromXMLAsync()
        {
            var resultExpect = "301";
            var build = new BuildSettings();
            Stamp stamp = new Stamp(build.Url, build.Token);
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/cfdi40_ansi.xml"));
            var response = await stamp.TimbrarV1Async(xml);
            Assert.True(response.Message.Contains(resultExpect), "Result not expected. Error: " + response.Message);
            Assert.Contains("Error al leer el documento XML. La estructura del documento no es un Xml valido", response.MessageDetail);
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
                string xml = GetXml(build);
                xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
                listXmlResult.Add(response);
            }
            if (listXmlResult != null)
                resultExpect = listXmlResult.FindAll(w => w.Status == "success" || w.Message.Contains("72 horas")).Count == iterations;

            Assert.True((bool)resultExpect);
        }
        [Fact]
        public async Task Stamp_Test_TimbrarV1TooLongAsync_Error()
        {
            var resultExpect = "En este path sólo es posible timbrar facturas que tengan más de 10000 nodos" +
                "cfdi:Concepto , favor de utiliza el timbrado normal";
            var build = new BuildSettings();
            StampV4 stamp = new StampV4(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV1)await stamp.TimbrarV1TooLongAsync(xml);
            Assert.True(response.Status == "error"
                && !string.IsNullOrEmpty(response.Message), resultExpect);
        }
        private string GetXml(BuildSettings build, string fileName = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(String.Format("Resources/CFDI40/{0}", fileName ?? "cfdi40.xml")));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
