﻿using System;
using System.Text;
using SW.Services.Validate;
using Test_SW.Helpers;
using System.IO;
using Xunit;
using System.Threading.Tasks;
using Test_SW.Helper;
using System.Linq;

namespace Test_SW_sdk.Services.Validate_Test
{
    public class Validate_UT
    {
        [Fact]
        public async Task ValidateXML_UT_OkAsync()
        {
            var build = new BuildSettings();
            Validate validate = new Validate(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            ValidateXmlResponse response = await validate.ValidateXmlAsync(xml.ToString());
            CustomAssert.SuccessResponse(response, response.Detail.ElementAt(1));
            Assert.True(!string.IsNullOrEmpty(response.StatusCodeSat), "N - 601: La expresión impresa proporcionada no es válida.");
        }
        [Fact]
        public async Task Validate_Test_ValidateXMLErrorAsync()
        {
            var build = new BuildSettings();
            Validate validate = new Validate(build.Url, build.User, build.Password);
            var xml = "";
            ValidateXmlResponse response = await validate.ValidateXmlAsync(xml);
            CustomAssert.ErrorResponse(response);
            Assert.True(!string.IsNullOrEmpty(response.Status), "Error al leer el documento XML. La estructura del documento no es un Xml valido y/o la codificación del documento no es UTF8. Root element is missing.");
        }
        private object GetXml(BuildSettings build)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/cfdi40.xml"));
            xml = SignTools.SigXml(xml, Convert.FromBase64String(build.Pfx), build.PfxPassword);
            return xml;
        }
    }
}
